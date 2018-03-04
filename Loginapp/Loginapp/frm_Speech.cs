using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace Loginapp
{
    public partial class frm_Speech : Form
    {
        public frm_Speech()
        {
            InitializeComponent();
        }
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void btn_speak_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox1.Text);
            }

            else
            {
                MessageBox.Show("enter some text");
            }

        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if(reader != null)
            {
                if(reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }
    }
}
