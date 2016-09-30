using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using ReadWriteMemory;
using Memory;

namespace PCModTool
{
    public partial class Form1 : Form
    {
        Process[] processname;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        private static unsafe extern Boolean WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int nSize, void* lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern Int32 CloseHandle(IntPtr hObject);

        static public IntPtr MemoryOpen(int ProcessID)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessID);
            return hProcess;
        }
        unsafe public void Write(uint mAddress, byte[] Buffer, int ProcessID)
        {
            if (MemoryOpen(ProcessID) == (IntPtr)0x00000000)
            {
                return;
            }

            if (!WriteProcessMemory(MemoryOpen(ProcessID), mAddress, Buffer, Buffer.Length, null))
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processname = Process.GetProcessesByName("iw4mp");
            if (processname.Length == 0)
            {
                MessageBox.Show("The game process was not detected!\nPlease open the game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusStrip1.Text = "Not Connected (Error at connection)";
                toolStripStatusLabel1.Text = "Not Connected";
                toolStripStatusLabel1.ForeColor = Color.Red;
                MW2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Connected!", "Connection Sucessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusStrip1.Text = "Connected - Call of Duty - Modern Warfare 2 MP";
                toolStripStatusLabel1.Text = "Connected";
                toolStripStatusLabel1.ForeColor = Color.Green;
                MW2.Enabled = true;

                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox1.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B790, Buffer, processname[0].Id);
                Write(0xBB3C24F8, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox2.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x1B8B768, Buffer, processname[0].Id);
                Write(0x33BBEB98, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox3.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B7B0, Buffer, processname[0].Id);
                Write(0x33BC13C8, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox4.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B7B4, Buffer, processname[0].Id);
                Write(0x33BC1738, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox5.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B77C, Buffer, processname[0].Id);
                Write(0x33BC2188, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox6.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B784, Buffer, processname[0].Id);
                Write(0x33BC2F48, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox7.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BB40, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox8.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BB80, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox9.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BBC0, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox10.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B7B8, Buffer, processname[0].Id);
                Write(0x33BC1AA8, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox11.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B7BC, Buffer, processname[0].Id);
                Write(0x33BC1E18, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox12.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B78C, Buffer, processname[0].Id);
                Write(0x33BC2868, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox13.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B8B780, Buffer, processname[0].Id);
                Write(0x33BC2BD8, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox14.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BC00, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox15.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BC40, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox16.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BC80, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox17.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BCC0, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox18.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BD00, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox19.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BD40, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox20.Text;
                byte[] Buffer = Encoding.ASCII.GetBytes(Convert.ToString(Value));﻿
                Write(0x01B8BD80, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }
       
        // Byte value example
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                // Get the name of process and don't stop until it is found
                processname = Process.GetProcessesByName("iw4mp");
                // Create an array of bytes and give value
                byte[] Buffer = { 0x01 }; //on
                // Write the value to the specified memory offset
                // Takes in offset, Buffer and processname args
                Write(0x06386D58, Buffer, processname[0].Id);
                // close
                CloseHandle(MemoryOpen(processname[0].Id));                              
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off (default value)
                Write(0x06386D58, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));                          
            }
               
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x0639A55C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x0639A55C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x04 }; //on
                Write(0x06E661A4, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x09 }; //off
                Write(0x06E661A4, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 117 }; //on
                Write(0x004AFA7B, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 116 }; //off
                Write(0x004AFA7B, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 1 }; //on
                Write(0x0639AD60, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0 }; //off
                Write(0x0639AD60, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }
        // '4 byte exact value' example
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                // create array of bytes, due to it being 4 bytes, in order for it to work
                // the byte array must be converted to 32 bit integer
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(1)); //on
                Write(0x063819EC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(0)); //off
                Write(0x063819EC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x02 }; //on
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //on
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id)); 
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x02 }; //on
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x03 }; //on
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x0638FE84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x02 }; //on
                Write(0x0638FF68, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x0638FF68, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //on
                Write(0x063931E0, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x063931E0, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //on
                Write(0x06393310, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x06393310, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

       
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(1)); //on
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(0)); //off
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

       
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(2)); //on
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(0)); //off
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(4)); //on
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(0)); //off
                Write(0x01B181AC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x06383A48, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06383A48, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //on
                Write(0x063909CC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //off
                Write(0x063909CC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(0)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            
            if (trackBar1.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar1.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar1.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar1.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar1.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5)); //on
                Write(0x063818BC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(0)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar2.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar2.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar2.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar2.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar2.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5)); //on
                Write(0x063916DC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.2)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.5)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.2)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.5)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar3.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.2)); //on
                Write(0x0638956C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (trackBar4.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 8)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 9)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.5)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar4.Value == 10)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(6)); //on
                Write(0x0639AD14, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (trackBar5.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(40)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(50)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(60)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(70)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(80)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(90)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(100)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(105)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 8)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(110)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 9)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(115)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar5.Value == 10)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(120)); //on
                Write(0x0639322C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x0639F240, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x0639F240, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x06390FBC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06390FBC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x02 }; //on
                Write(0x06390FBC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06390FBC, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x06390D5C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06390D5C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0 }; //on
                Write(0x0086A26C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 96 }; //off
                Write(0x0086A26C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox21.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(Value));
                Write(0x0639925C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox22.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(Value));
                Write(0x063992A8, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox23.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(Value));
                Write(0x063992F4, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (trackBar6.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(0.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.0)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.0)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.0)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.0)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 8)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 9)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.0)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar6.Value == 10)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.5)); //on
                Write(0x06394A84, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            if (trackBar7.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(0.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.0)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.0)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.0)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.0)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 8)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 9)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.0)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar7.Value == 10)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.5)); //on
                Write(0x06394B1C, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            if (trackBar8.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(0.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.0)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(1.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 3)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.0)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 4)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(2.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 5)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.0)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 6)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(3.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 7)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.0)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 8)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(4.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 9)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.0)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar8.Value == 10)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = BitConverter.GetBytes(Convert.ToSingle(5.5)); //on
                Write(0x06394A38, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            if (trackBar9.Value == 0)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0 }; //on
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar9.Value == 1)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 1 }; //on
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

            if (trackBar9.Value == 2)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 2 }; //on
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox24.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B15104, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            if (textBox25.Text == "")
            {

            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                string Value = textBox25.Text;
                byte[] Buffer = BitConverter.GetBytes(Convert.ToInt32(Value));
                Write(0x01B150F4, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x01 }; //on
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
            else
            {
                processname = Process.GetProcessesByName("iw4mp");
                byte[] Buffer = { 0x00 }; //off
                Write(0x06391008, Buffer, processname[0].Id);
                CloseHandle(MemoryOpen(processname[0].Id));
            }
        }

                          
    }
}