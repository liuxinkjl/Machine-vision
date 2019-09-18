using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;

namespace Gige_Vidion_Camera
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
            m_AcqDevice = null;
            m_Buffers = null;
            m_Xfer = null;
            m_View = null;
                // Note:
                //  The code to initialize m_ImageBox was originally in the InitializeComponent function
                //  called above. However, it has been moved to the dialog constructor as a workaround
                //  to a Visual Studio Designer error when loading the DALSA.SaperaLT.SapClassBasic
                //  assembly under 64-bit Windows.
                //  As a consequence, it is not possible to adjust the m_ImageBox properties
                //  automatically using the Designer anymore, this has to be done manually.
                // 
                this.m_ImageBox = new DALSA.SaperaLT.SapClassGui.ImageBox();
                this.m_ImageBox.Location = new System.Drawing.Point(241, 4);
                this.m_ImageBox.Name = "m_ImageBox";
                this.m_ImageBox.PixelValueDisplay = this.PixelDataValue;
                this.m_ImageBox.Size = new System.Drawing.Size(386, 359);
                this.m_ImageBox.SliderEnable = true;
                this.m_ImageBox.SliderMaximum = 10;
                this.m_ImageBox.SliderMinimum = 0;
                this.m_ImageBox.SliderValue = 0;
                this.m_ImageBox.SliderVisible = false;
                this.m_ImageBox.TabIndex = 12;
                this.m_ImageBox.TrackerEnable = false;
                this.m_ImageBox.View = null;
                this.Controls.Add(this.m_ImageBox);

                
        }
        private SapAcqDevice m_AcqDevice;
        private SapBuffer m_Buffers;
        private SapAcqDeviceToBuf m_Xfer;
        private SapView m_View;
        private SapLocation m_ServerLocation;
        private string m_ConfigFileName;
        private ImageBox m_ImageBox;
        private delegate void DisplayFrameAcquired(int number, bool trash);
        static void xfer_XferNotify(object sender, SapXferNotifyEventArgs argsNotify)
        {
            Homepage GigeDlg = argsNotify.Context as Homepage;
            // If grabbing in trash buffer, do not display the image, update the
            // appropriate number of frames on the status bar instead
            if (argsNotify.Trash)
                GigeDlg.Invoke(new DisplayFrameAcquired(GigeDlg.ShowFrameNumber), argsNotify.EventCount, true);
            else
            {
                GigeDlg.Invoke(new DisplayFrameAcquired(GigeDlg.ShowFrameNumber), argsNotify.EventCount, false);
                GigeDlg.m_View.Show();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
     /// <summary>
     /// 初始化设备
     /// </summary>
     /// <param name="acConfigDlg"></param>
     /// <param name="Restore"></param>
     /// <returns></returns>
        public bool CreateNewObjects(AcqConfigDlg acConfigDlg, bool Restore)
        {
            if (!Restore)
            {
                m_ServerLocation = acConfigDlg.ServerLocation;
                m_ConfigFileName = acConfigDlg.ConfigFile;
            }
            m_AcqDevice = new SapAcqDevice(m_ServerLocation, m_ConfigFileName);
            if (SapBuffer.IsBufferTypeSupported(m_ServerLocation, SapBuffer.MemoryType.ScatterGather))
                m_Buffers = new SapBufferWithTrash(2, m_AcqDevice, SapBuffer.MemoryType.ScatterGather);
            else
                m_Buffers = new SapBufferWithTrash(2, m_AcqDevice, SapBuffer.MemoryType.ScatterGatherPhysical);
            m_Xfer = new SapAcqDeviceToBuf(m_AcqDevice, m_Buffers);
            m_View = new SapView(m_Buffers);
            m_ImageBox.View = m_View;

            m_Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            m_Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            m_Xfer.XferNotifyContext = this;
            StatusLabelInfo.Text = "Online... Waiting grabbed images";

            if (!CreateObjects())
            {
                DisposeObjects();
                return false;
            }

            // Resize ImagBox to take into account the size of created sapview
            m_ImageBox.OnSize();
            UpdateControls();
            return true;
        }
        /// <summary>
        /// 找寻框架
        /// </summary>
        /// <param name="number"></param>
        /// <param name="trash"></param>
        private void ShowFrameNumber(int number, bool trash)
        {
            String str;
            if (trash)
            {
                str = String.Format("Frames acquired in trash buffer: {0}", number);
                Console.WriteLine(str);
            }
            else
            {
                str = String.Format("Frames acquired :{0}", number);
                this.StatusLabelInfo.Text = str;
            }
        }
        /// <summary>
        /// 注册回调
        /// </summary>
        /// <returns></returns>
        private bool CreateObjects()
        {
            // Create acquisition object
            if (m_AcqDevice != null && !m_AcqDevice.Initialized)
            {
                if (m_AcqDevice.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }
            // Create buffer object
            if (m_Buffers != null && !m_Buffers.Initialized)
            {
                if (m_Buffers.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
                m_Buffers.Clear();
            }
            // Create view object
            if (m_View != null && !m_View.Initialized)
            {
                if (m_View.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }

            if (m_Xfer != null && m_Xfer.Pairs[0] != null)
            {
                m_Xfer.Pairs[0].Cycle = SapXferPair.CycleMode.NextWithTrash;
                if (m_Xfer.Pairs[0].Cycle != SapXferPair.CycleMode.NextWithTrash)
                {
                    DestroyObjects();
                    return false;
                }
            }

            // Create Xfer object
            if (m_Xfer != null && !m_Xfer.Initialized)
            {
                if (m_Xfer.Create() == false)
                {
                    DestroyObjects();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 清理内存
        /// </summary>
        private void DestroyObjects()
        {
            if (m_Xfer != null && m_Xfer.Initialized)
                m_Xfer.Destroy();
            if (m_View != null && m_View.Initialized)
                m_View.Destroy();
            if (m_Buffers != null && m_Buffers.Initialized)
                m_Buffers.Destroy();
            if (m_AcqDevice != null && m_AcqDevice.Initialized)
                m_AcqDevice.Destroy();
        }
        /// <summary>
        /// 释放句柄
        /// </summary>
        private void DisposeObjects()
        {
            if (m_Xfer != null)
            { m_Xfer.Dispose(); m_Xfer = null; }
            if (m_View != null)
            { m_View.Dispose(); m_View = null; m_ImageBox.View = null; }
            if (m_Buffers != null)
            { m_Buffers.Dispose(); m_Buffers = null; }
            if (m_AcqDevice != null)
            { m_AcqDevice.Dispose(); m_AcqDevice = null; }
        }
        /// <summary>
        /// 控制button状态
        /// </summary>
        void UpdateControls()
        {
            bool bAcqNoGrab = (m_Xfer != null) && (m_Xfer.Grabbing == false);
            bool bAcqGrab = (m_Xfer != null) && (m_Xfer.Grabbing == true);
            bool bNoGrab = (m_Xfer == null) || (m_Xfer.Grabbing == false);

            // Acquisition Control
            button_grab.Enabled = bAcqNoGrab;
            //button_Snap.Enabled = bAcqNoGrab;
            button_freeze.Enabled = bAcqGrab;

            //// File Options
            //button_New.Enabled = bNoGrab;
            //button_Load.Enabled = bNoGrab;
            //button_Save.Enabled = bNoGrab;

            //button_Load_Config.Enabled = bAcqNoGrab;
            //button_Buffer.Enabled = bNoGrab;
        }
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_opencamera_Click(object sender, EventArgs e)
        {
            AcqConfigDlg acConfigDlg = new AcqConfigDlg(null, "", AcqConfigDlg.ServerCategory.ServerAcqDevice);
            if (acConfigDlg.ShowDialog() == DialogResult.OK)
            {
                if (!CreateNewObjects(acConfigDlg, false)) this.Close();
            }
            else
            {
                MessageBox.Show("No GigE-Vision cameras found or selected");
                this.Close();
            }
        }
        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_grab_Click(object sender, EventArgs e)
        {
            this.StatusLabelInfo.Text = "";
            //this.StatusLabelInfoTrash.Text = "";
            if (m_Xfer.Grab())
            {
                UpdateControls();
            }
        }
        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_freeze_Click(object sender, EventArgs e)
        {
            AbortDlg abort = new AbortDlg(m_Xfer);
            if (m_Xfer.Freeze())
            {
                if (abort.ShowDialog() != DialogResult.OK)
                    m_Xfer.Abort();
                UpdateControls();
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_closecamera_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 调整图像参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_View_Click(object sender, EventArgs e)
        {
            ViewDlg viewDialog = new ViewDlg(m_View, m_ImageBox.ViewRectangle);

            if (viewDialog.ShowDialog() == DialogResult.OK)
                m_ImageBox.OnSize();

            m_ImageBox.Refresh();
        }
    }
}
