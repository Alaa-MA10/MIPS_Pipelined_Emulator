using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archi_Template
{
     class MIPS
     {
          public static int[] Register = new int[32];

          public static string IF_IDReg, ID_EXReg, EX_MEMReg, MEM_WBReg,
                               PC_Reg, Beq_PC="";

          public static string[] instr;
          int instr_index = 0;
          public static char PCSrc = '0';

          public static Hashtable instruct_mem = new Hashtable();
          Pipeline_Stages stage = new Pipeline_Stages();

          public static Queue qFetch = new Queue(),
                              qDecode = new Queue(),
                              qExecute = new Queue(),
                              qMemory = new Queue(),
                              qWrite_Back = new Queue();

          
          public MIPS()
          {
               
               // Initialize register values
               Register[0] = 0;
               for (int i = 1; i < Register.Length; i++)
               {
                    Register[i] = 100 + i;
               }

               PC_Reg = "1000";
               IF_IDReg = "";  ID_EXReg = "";
               EX_MEMReg = ""; MEM_WBReg = "";
          }

          public void Run_1Cycle()
          {
               if (qWrite_Back.Count != 0)
               {
                    qWrite_Back.Dequeue();
                    stage.Write_Back();
               }

               if (qMemory.Count != 0)
               {
                    if (EX_MEMReg != "")
                    {
                         qWrite_Back.Enqueue(qMemory.Dequeue());
                         stage.Memory_Access();
                    }
               }

               if (qExecute.Count != 0)
               {
                    if (ID_EXReg != "")
                    {
                         qMemory.Enqueue(qExecute.Dequeue());
                         stage.Execute();
                    }
               }

               if (qDecode.Count != 0)
               {
                    if (IF_IDReg != "")
                    {
                         qExecute.Enqueue(qDecode.Dequeue());
                         stage.Decode();
                    }
               }

               if (instr_index < instr.Length)
               {
                    while (instr[instr_index].Split(':')[0] != PC_Reg && instr_index < instr.Length)
                    {
                         instr_index++;
                    }

                    stage.Fetch(instr[instr_index]);
                    qDecode.Enqueue(qFetch.Dequeue());
                    instr_index++;

               }
          }

     }
}
