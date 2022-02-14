using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace archi_Template
{
     public partial class Form1 : Form
     {
          MIPS mips_cycle;
          public Form1()
          {
               InitializeComponent();
          }

          private void inializeBtn_Click(object sender, EventArgs e)
          {
               mips_cycle = new MIPS();
               MipsRegisterGrid.Rows.Clear();
               Display_MIPS_Register(MipsRegisterGrid);
          }

          private void runCycleBtn_Click(object sender, EventArgs e)
          {
               string instruction = UserCodetxt.Text;
               MIPS.instr = instruction.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

               mips_cycle.Run_1Cycle();
               PiplineGrid.Rows.Clear();
               Display_Pipeline_Register(PiplineGrid);
               MipsRegisterGrid.Rows.Clear();
               Display_MIPS_Register(MipsRegisterGrid);  
          }


          public void Display_MIPS_Register(DataGridView DisplayGrid)
          {
               for (int i = 0; i < MIPS.Register.Count(); i++)
               {
                    DisplayGrid.Rows.Add("$" + i, MIPS.Register[i]);
               }
          }

          public void Display_Pipeline_Register(DataGridView DisplayGrid)
          {
               if (!MIPS.IF_IDReg.Equals(""))
               {
                    string[] IF_IDData = MIPS.IF_IDReg.Split('#');
                    string PC_Address = IF_IDData[0],
                           instruction = IF_IDData[1];
                    DisplayGrid.Rows.Add("IF/ID PC_Address", PC_Address);
                    DisplayGrid.Rows.Add("IF/ID instruction", instruction);
               }

               if (!MIPS.ID_EXReg.Equals(""))
               {
                    string[] ID_EXData = MIPS.ID_EXReg.Split('#');
                    string WB = ID_EXData[0],
                           M = ID_EXData[1],
                           EX = ID_EXData[2],
                           ALUOp = EX.Substring(1, 2),
                           PC_address = ID_EXData[3],
                           Read_data1 = ID_EXData[4],
                           Read_data2 = ID_EXData[5],
                           extend_address = ID_EXData[6],
                           ALU_funct = extend_address.Substring(26, 6),
                           instr20_16 = ID_EXData[7],
                           instr15_11 = ID_EXData[8];
                    char ALUSrc = EX[3],
                         RegDst = EX[0];

                    DisplayGrid.Rows.Add("ID/EX WB", WB);
                    DisplayGrid.Rows.Add("ID/EX M", M);
                    DisplayGrid.Rows.Add("ID/EX ALUOp", ALUOp);
                    DisplayGrid.Rows.Add("ID/EX ALUSrc", ALUSrc);
                    DisplayGrid.Rows.Add("ID/EX RegDst", RegDst);
                    DisplayGrid.Rows.Add("ID/EX PC_address", PC_address);
                    DisplayGrid.Rows.Add("ID/EX Read data1", Read_data1);
                    DisplayGrid.Rows.Add("ID/EX Read data2", Read_data2);
                    DisplayGrid.Rows.Add("ID/EX extend_address", extend_address);
                    DisplayGrid.Rows.Add("ID/EX instr[20-16]", instr20_16);
                    DisplayGrid.Rows.Add("ID/EX instr[15-11]", instr15_11);
               }
               if (!MIPS.EX_MEMReg.Equals(""))
               {
                    string[] EX_MEMData = MIPS.EX_MEMReg.Split('#');
                    string WB = EX_MEMData[0],
                      M = EX_MEMData[1],
                      PC_address = EX_MEMData[2],
                      ALU_zero = EX_MEMData[3],
                      Alu_res = EX_MEMData[4],
                      Write_data = EX_MEMData[5],
                      RegDst_res = EX_MEMData[6];

                    char Branch_stat = M[0],
                         MemRead = M[1],
                         MemWrite = M[2];

                    DisplayGrid.Rows.Add("EX_MEM WB", WB);
                    DisplayGrid.Rows.Add("EX_MEM Brach", Branch_stat);
                    DisplayGrid.Rows.Add("EX_MEM MemRead", MemRead);
                    DisplayGrid.Rows.Add("EX_MEM MemWrite", MemWrite);
                    DisplayGrid.Rows.Add("EX_MEM PC_address", PC_address);
                    DisplayGrid.Rows.Add("EX_MEM ALU Zero", ALU_zero);
                    DisplayGrid.Rows.Add("EX_MEM ALU Res", Alu_res);
                    DisplayGrid.Rows.Add("EX_MEM Write data", Write_data);
                    DisplayGrid.Rows.Add("EX_MEM RegDst Res", RegDst_res);

               }
               if (!MIPS.MEM_WBReg.Equals(""))
               {
                    string[] MEM_WBData = MIPS.MEM_WBReg.Split('#');
                    string WB = MEM_WBData[0],
                           Read_data = MEM_WBData[1],
                           Alu_res = MEM_WBData[2],
                           RegDst = MEM_WBData[3];

                    char RegWrite = WB[0],
                         MemToReg = WB[1];

                    DisplayGrid.Rows.Add("MEM_WB RegWrite", RegWrite);
                    DisplayGrid.Rows.Add("MEM_WB MemToReg", MemToReg);
                    DisplayGrid.Rows.Add("MEM_WB Read data", Read_data);
                    DisplayGrid.Rows.Add("MEM_WB ALU Res", Alu_res);
                    DisplayGrid.Rows.Add("MEM_WB RegDst Res", RegDst);

               }

          }
     }
}
