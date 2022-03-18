using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace bio
{
    public partial class TopologyPopupForm : Form
    {
        private Label lblTopologyHint;
        private Button close;
        private TreeView treeView1;
    
        public TopologyPopupForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void buildTopologyTree(string strXml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(strXml);
            treeView1.Nodes.Clear();

            XmlNode startNode = xdoc.DocumentElement.ChildNodes[0].ChildNodes[0];
            treeView1.Nodes.Add(new TreeNode("scanners", 14, 14));
            TreeNode tNode = new TreeNode();
            tNode = treeView1.Nodes[0];
            AddNode(startNode, tNode);
        }

        private void getModelAndIcon(XmlNodeList nodeList,ref string scanner_ID, ref string model_name, ref int index)
        {
            XmlNode xNode;
            string prfx_mod_name;
            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                xNode = nodeList[i];
                if ("modelnumber" == xNode.Name)
                {
                    if ((xNode.ChildNodes.Count > 0) && (null != xNode.ChildNodes[0].Value))
                    {
                        model_name = xNode.ChildNodes[0].Value;
                        prfx_mod_name = xNode.ChildNodes[0].Value.Substring(0, 6);
                    }
                    else
                    {
                        prfx_mod_name = "";
                        model_name = "Unknown";
                    }
                    switch (prfx_mod_name)
                    {
                        case "DS6707":
                            index = 0;
                            break;
                        case "DS9808":
                            index = 1;
                            break;
                        case "LS1203":
                            index = 2;
                            break;
                        case "LS2208":
                            index = 3;
                            break;
                        case "LS3008":
                            index = 4;
                            break;
                        case "LS3408":
                            index = 5;
                            break;
                        case "LS3578":
                            index = 6;
                            break;
                        case "LS4208":
                            index = 7;
                            break;
                        case "LS4278":
                            index = 8;
                            break;
                        case "LS9203":
                            index = 9;
                            break;
                        case "STB427":
                            index = 11;
                            break;
                        default:
                            //model_name = "Unknown";
                            index = 12;
                            break;
                    }
                }
                else if ("scannerID" == xNode.Name)
                {
                    scanner_ID = xNode.ChildNodes[0].Value;
                }
                else if ("scanner" == xNode.Name)
                {
                    if (12 == index)
                        index = 13;
                    return; //cradel model name follows child scanners
                    // so if it returns from here, model_name will have cradle model name  
                }
            }
            return;
        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i, j;



            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                string model_name = "";
                string scanner_ID = "";
                int index = 0;

                for (i = 0, j = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = nodeList[i];
                    if (xNode.HasChildNodes)
                    {
                        if ("scanner" == xNode.Name)
                        {
                            getModelAndIcon(xNode.ChildNodes,ref scanner_ID, ref model_name, ref index);
                            inTreeNode.Nodes.Add(new TreeNode("ID = "+scanner_ID+" : "+model_name, index, index));
                            tNode = inTreeNode.Nodes[j++];
                            AddNode(xNode, tNode);
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblTopologyHint = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(9, 9);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(360, 216);
            this.treeView1.TabIndex = 1;
            // 
            // lblTopologyHint
            // 
            this.lblTopologyHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTopologyHint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTopologyHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopologyHint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTopologyHint.ImageIndex = 12;
            this.lblTopologyHint.Location = new System.Drawing.Point(114, 235);
            this.lblTopologyHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopologyHint.Name = "lblTopologyHint";
            this.lblTopologyHint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTopologyHint.Size = new System.Drawing.Size(255, 28);
            this.lblTopologyHint.TabIndex = 3;
            this.lblTopologyHint.Text = "Hint: Unknown/Non-RSM scanner is shown as ";
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.close.Location = new System.Drawing.Point(12, 235);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(68, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click_1);
            // 
            // TopologyPopupForm
            // 
            this.ClientSize = new System.Drawing.Size(697, 326);
            this.Controls.Add(this.close);
            this.Controls.Add(this.lblTopologyHint);
            this.Controls.Add(this.treeView1);
            this.Name = "TopologyPopupForm";
            this.ResumeLayout(false);

        }

        private void close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}