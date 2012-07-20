using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TikTakToe
{
    public partial class Form1 : Form
    {
        bool is2Player = false;
        bool is1Player = false;
        static int counter = 0;
        string[] pattern = { "123", "456", "789", "159", "357", "147", "258", "369" };
        public Form1()
        {

            InitializeComponent();
            button10.Focus();
            
        }

        
        private void button10_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Choose(Control button)
        {
            string str = string.Empty;
            int index = 0;


            if (is2Player || is1Player)
            {
                if (counter % 2 == 0)
                {
                    str = button.Text = "O";
                    button.Enabled = false;
                    index = button.TabIndex;
                }
                else
                {
                    str = button.Text = "X";
                    button.Enabled = false;
                    index = button.TabIndex;
                }
                counter++;
                Winner(button, str);
                if (is1Player)
                    str= Player(index, str);
                Winner(button, str);
            }

        }

        private string Player(int index, string _text) 
        {
            Control[] arrayButton = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            string holder = string.Empty;
            int xchecker=0;
            int checker = 0;
            int x;
            int check;
            int xcheck=0;

            string temp = string.Empty;
            if (_text == "X")
                temp = "O";
            else
                temp = "X";


            if (index == 5 || index == 9)
            {
                if (button1.Enabled)
                    x = 0;
                else
                    x = 2;
                if (counter % 2 == 0 && button3.Enabled && button1.Enabled)
                {
                    arrayButton[x].Text = "O";
                    arrayButton[x].Enabled = false;
                    counter++;
                    return arrayButton[x].Text;
                }
                else if(button3.Enabled)
                {
                    arrayButton[x].Text = "X";
                    arrayButton[x].Enabled = false;
                    counter++;
                    return arrayButton[x].Text;
                }
                
                
            }



            for (int i = 0; i <arrayButton.Count() ; i++)
            {
                    if (string.Compare(arrayButton[i].Text, _text, true) == 0)
                    {
                        holder = holder +  arrayButton[i].TabIndex;
                        
                    } 
            }

            for (int i = 0; i < pattern.Count(); i++)
            {
                xcheck = 0;

                    char[] pat = pattern[i].ToCharArray();
                    if (!holder.Contains(pat[0]))
                    {
                        xchecker = int.Parse((pat[0]).ToString()) - 1;
                        xcheck++;
                    }
                    if (!holder.Contains(pat[1]))
                    {
                         xchecker = int.Parse((pat[1]).ToString()) - 1;
                         xcheck++;
                    }
                    if (!holder.Contains(pat[2]))
                    {
                        xchecker = int.Parse((pat[2]).ToString()) - 1;
                        xcheck++;
                    }

                    if (xcheck == 1 && arrayButton[xchecker].Enabled == true)
                    {
                        if (counter % 2 == 0)
                        {
                            arrayButton[xchecker].Text = "O";
                            arrayButton[xchecker].Enabled = false;
                        }
                        else
                        {
                            arrayButton[xchecker].Text = "X";
                            arrayButton[xchecker].Enabled = false;
                        }
                        counter++;
                        return arrayButton[xchecker].Text;
                    }
                   
            }
            holder = string.Empty;
            for (int i = 0; i < arrayButton.Count(); i++)
            {
                if (string.Compare(arrayButton[i].Text, temp, true) == 0)
                {
                    holder = holder + arrayButton[i].TabIndex;

                }
            }

            for (int i = 0; i < pattern.Count(); i++)
            {
                check = 0;

                char[] pat = pattern[i].ToCharArray();
                if (!holder.Contains(pat[0]))
                {
                    checker = int.Parse((pat[0]).ToString()) - 1;
                    check++;
                }
                if (!holder.Contains(pat[1]))
                {
                    checker = int.Parse((pat[1]).ToString()) - 1;
                    check++;
                }
                if (!holder.Contains(pat[2]))
                {
                    checker = int.Parse((pat[2]).ToString()) - 1;
                    check++;
                }

                if (check ==1 && arrayButton[checker].Enabled == true)
                {
                    if (counter % 2 == 0)
                    {
                        arrayButton[checker].Text = "O";
                        arrayButton[checker].Enabled = false;
                    }
                    else
                    {
                        arrayButton[checker].Text = "X";
                        arrayButton[checker].Enabled = false;
                    }
                    counter++;
                    return arrayButton[checker].Text;
                }

              
                
            }

            if (index != 5 )
            {
                x = 4;
                if (button5.Enabled ==true)
                {
                    if (counter % 2 == 0)
                    {
                        arrayButton[x].Text = "O";
                        arrayButton[x].Enabled = false;
                    }
                    else
                    {
                        arrayButton[x].Text = "X";
                        arrayButton[x].Enabled = false;
                    }
                    counter++;
                    return arrayButton[x].Text; 
                }
            }
            //else 
            //{

                for (int i = 0; i < pattern.Count(); i++)
                {
                    check = 0;
                    for (int j = 0; j < pattern[i].Count(); j++)
                    {

                        char[] pat = pattern[i].ToCharArray();
                        checker = int.Parse((pat[j]).ToString()) - 1;
                        if (arrayButton[checker].Enabled == true)
                        {
                            if (counter % 2 == 0)
                            {
                                arrayButton[checker].Text = "O";
                                arrayButton[checker].Enabled = false;
                            }
                            else
                            {
                                arrayButton[checker].Text = "X";
                                arrayButton[checker].Enabled = false;
                            }
                            counter++;
                            return arrayButton[checker].Text;
                        }
                    }
                }


            //}
            return _text;
        }

        private void Winner(Control button,string _text) 
        {
            Control[] arrayButton = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            string holder=string.Empty;
            int check = 0;
            
            if (counter > 4)
            {
                for (int i = 0; i <arrayButton.Count() ; i++)
                {
                    if (string.Compare(arrayButton[i].Text, _text, true) == 0)
                    {
                        holder = holder +  arrayButton[i].TabIndex;
                        //counter = 0;
                        
                    } 
                }

                for (int i = 0; i < pattern.Count(); i++)
                {
                    check = 0;
                    for (int j = 0; j < pattern[i].Count(); j++)
                    {
                        
                        char[] pat = pattern[i].ToCharArray();
                        if (holder.Contains(pat[j]))
                        {
                            check++;   
                        }
                        if (check == 3)
                        {
                            MessageBox.Show(_text + " Player Won the Game");
                            Reset();
                            return;
                        }
                    }
                }
                
            }

        }

        private void Reset() 
        {
            Control[] arrayButton = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            for (int i = 0; i < arrayButton.Count(); i++)
            {

                arrayButton[i].Enabled = true;
                arrayButton[i].Text = "";
                
            }
            button10.Focus();
            is2Player = false;
            is1Player = false;
        }
        private void TossCoin()
        { 
            Random ran = new Random();
            int iRandom = ran.Next(0, 100);
            if (iRandom%2==0)
            {
                
            }
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Choose(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Choose(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Choose(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Choose(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Choose(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Choose(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Choose(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Choose(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Choose(button9);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!is1Player)
                is2Player = true; 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!is2Player)
                is1Player = true;
        }

    }
}
