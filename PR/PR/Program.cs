using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Spire.Presentation;
using Spire.Presentation.Diagrams;
using System.Drawing;

namespace PR
{

    class Program
    {
        String BaseDir = "T:\\厦门天马\\厦门研发部\\部门内可读\\研发电子设计\\EE手机消费品组Work Report\\相关项目ISSUE报告";
        String[] Owners;
        String[] Name;





        Boolean Init;
        Dictionary<String, String> Cover;
        Dictionary<String, String> ProjectStatus;
        Dictionary<String, String> Timeline;
        Dictionary<String, String> Problem;
        void Read(String IN,String OUT)
        {
            Presentation test = new Presentation(@IN, FileFormat.Pptx2010);
            StringWriter sw = new StringWriter();
            foreach (ISlide slide in test.Slides)
            {
                sw.WriteLine("==========================分页符==========================");
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IAutoShape)
                    {
                        ITextFrameProperties TF = (shape as IAutoShape).TextFrame;
                        if (TF != null)
                        {
                            foreach (TextParagraph text in TF.Paragraphs)
                            {

                                sw.WriteLine(text.Text);
                            }
                        }

                    }
                    if(shape is ISmartArt)
                    {
                        sw.WriteLine("##########################SmartArt##########################");
                        ISmartArt SA = (shape as ISmartArt);
                        for(int i = 0; i < SA.Nodes.Count; i++)
                        {
                            ITextFrameProperties TF = SA.Nodes[i].TextFrame;
                            if (TF != null)
                            {
                                foreach (TextParagraph text in TF.Paragraphs)
                                {

                                    sw.WriteLine(text.Text);
                                }
                            }
                            sw.WriteLine("→→→Node→→→");
                        }
                        sw.WriteLine("##########################SmartArt##########################");
                    }
                }
            }
            File.WriteAllText(OUT, sw.ToString());
        } 
        public Program()
        {
            Owners = Directory.GetDirectories(BaseDir);
            Name = new String[Owners.Length];

            Init = true;
            this.Cover = new Dictionary<string, string>();
            Cover.Add("Department", "部门");
            Cover.Add("Reporter", "报告人");
            Cover.Add("Date", "报告时间");
            this.ProjectStatus = new Dictionary<string, string>();
            ProjectStatus.Add("Title", "项目");
            ProjectStatus.Add("Owner", "负责人");
            ProjectStatus.Add("Client", "客户");
            ProjectStatus.Add("ID", "项目号");
            ProjectStatus.Add("Panel", "面板");
            ProjectStatus.Add("IC", "IC");
            ProjectStatus.Add("Voltage", "电压");
            ProjectStatus.Add("Resolution", "分辨率");
            ProjectStatus.Add("Status", "状态");
            ProjectStatus.Add("Factory", "产线");
            ProjectStatus.Add("Briefing", "项目进展概况");
            this.Timeline = new Dictionary<string, string>();
            Timeline.Add("时程点", "事件");
            this.Problem = new Dictionary<string, string>();
            Problem.Add("Title", "问题名称");
            Problem.Add("ID", "项目号");
            Problem.Add("Percentage", "比例");
            Problem.Add("Factory", "产线");
            Problem.Add("Type", "问题类型");
            Problem.Add("Note", "备注");
            Problem.Add("Amount", "NG数量/总投产量");
            Problem.Add("Date", "发生时间");
            Problem.Add("Projects_SameIC", "同IC项目");
            Problem.Add("Projects_SamePanel", "同面板项目");
            Problem.Add("Projects_SameIssueType", "同问题项目");
            Problem.Add("Projects_SameFactory", "同产线项目");
            Problem.Add("Issues_SameIC", "IC问题点");
            Problem.Add("Issues_SamePanel", "面板问题点");
            Problem.Add("Issues_SameIssueType", "其它问题点");
            Problem.Add("Issues_SameFactory", "产线问题点");
        }
        void CoverProcess(ISlide CoverPage)
        {
            int j = 0;
            IAutoShape Department = CoverPage.Shapes[0] as IAutoShape;
            IAutoShape Reporter = CoverPage.Shapes[0] as IAutoShape;
            IAutoShape Date = CoverPage.Shapes[0] as IAutoShape;
            for (int i = 0; i < CoverPage.Shapes.Count; i++)
            {
                if (CoverPage.Shapes[i] is IAutoShape)
                {
                    switch (j)
                    {
                        case 0:
                            Department = CoverPage.Shapes[i] as IAutoShape;
                            break;
                        case 1:
                            Reporter = CoverPage.Shapes[i] as IAutoShape;
                            break;
                        case 2:
                            Date = CoverPage.Shapes[i] as IAutoShape;
                            break;
                        default:
                            break;
                    }
                    j++;
                }
            }
            this.Cover["Department"] = Department.TextFrame.Text;
            this.Cover["Reporter"] = Reporter.TextFrame.Text;
            this.Cover["Date"] = Date.TextFrame.Text;
        }
        void ProStaProcess(ISlide PSPage)
        {
            int j = 0;
            IAutoShape Title = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Owner = PSPage.Shapes[0] as IAutoShape;
            IAutoShape ID = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Panel = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Client = PSPage.Shapes[0] as IAutoShape;
            IAutoShape IC = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Voltage = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Resolution = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Status = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Factory = PSPage.Shapes[0] as IAutoShape;
            IAutoShape Briefing = PSPage.Shapes[0] as IAutoShape;
            for (int i = 0; i < PSPage.Shapes.Count; i++)
            {
                if (PSPage.Shapes[i] is IAutoShape)
                {
                    switch (j)
                    {
                        case 0:
                            Title = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 1:
                            Owner = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 2:
                            ID = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 3:
                            Panel = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 4:
                            Client = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 5:
                            IC = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 6:
                            Voltage = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 7:
                            Resolution = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 8:
                            Status = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 9:
                            Factory = PSPage.Shapes[i] as IAutoShape;
                            break;
                        case 10:
                            Briefing = PSPage.Shapes[i] as IAutoShape;
                            break;
                        default:
                            break;
                    }
                    j++;
                }
            }
            this.ProjectStatus["Title"] = Title.TextFrame.Text;
            this.ProjectStatus["Owner"] = Owner.TextFrame.Text;
            this.ProjectStatus["ID"] = ID.TextFrame.Text;
            this.ProjectStatus["Panel"] = Panel.TextFrame.Text;
            this.ProjectStatus["Client"] = Client.TextFrame.Text;
            this.ProjectStatus["IC"] = IC.TextFrame.Text;
            this.ProjectStatus["Voltage"] = Voltage.TextFrame.Text;
            this.ProjectStatus["Resolution"] = Resolution.TextFrame.Text;
            this.ProjectStatus["Status"] = Status.TextFrame.Text;
            this.ProjectStatus["Factory"] = Factory.TextFrame.Text;
            this.ProjectStatus["Briefing"] = Briefing.TextFrame.Text;
        }
        void TimeLineProcess(ISlide PSPage)
        {
            for (int i = 0; i < PSPage.Shapes.Count; i++)
            {
                if (PSPage.Shapes[i] is ISmartArt)
                {
                    ISmartArt SA = PSPage.Shapes[i] as ISmartArt;
                    String Key = "";
                    for (int j = 0; j < SA.Nodes.Count; j++)
                    {
                        String Content = SA.Nodes[j].TextFrame.Text;
                        int Level = SA.Nodes[j].Level;
                        switch (Level)
                        {
                            case 0:
                                Timeline.Add(Content,"");
                                Key = Content;
                                break;
                            case 1:
                                String Temp = Timeline[Key];
                                Temp = Temp + Content + "\n";
                                Timeline[Key] = Temp;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }
        void ProblemProcss(ISlide ProbPage)
        {
            int j = 0;
            IAutoShape Title = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape ID = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Percentage = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Factory = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Type = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Note = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Amount = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Date = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Projects_SameIC = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Projects_SamePanel = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Projects_SameIssueType = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Projects_SameFactory = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Issues_SameIC = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Issues_SamePanel = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Issues_SameIssueType = ProbPage.Shapes[0] as IAutoShape;
            IAutoShape Issues_SameFactory = ProbPage.Shapes[0] as IAutoShape;
            for (int i = 0; i < ProbPage.Shapes.Count; i++)
            {
                if(ProbPage.Shapes[i] is IAutoShape)
                {
                    switch (j)
                    {
                        case 0:
                            Title = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 1:
                            ID = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 2:
                            Percentage = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 3:
                            Factory = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 4:
                            Type = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 5:
                            Note = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 6:
                            Amount = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 7:
                            Date = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 8:
                            Projects_SameIC = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 9:
                            Projects_SamePanel = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 10:
                            Projects_SameIssueType = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 11:
                            Projects_SameFactory = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 12:
                            Issues_SameIC = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 13:
                            Issues_SameFactory = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 14:
                            Issues_SamePanel = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        case 15:
                            Issues_SameIssueType = ProbPage.Shapes[i] as IAutoShape;
                            break;
                        default:
                            break;
                    }
                    j++;
                }
                Problem["Title"] = Title.TextFrame.Text;
                Problem["ID"] = ID.TextFrame.Text;
                Problem["Percentage"] = Percentage.TextFrame.Text;
                Problem["Factory"] = Factory.TextFrame.Text;
                Problem["Type"] = Type.TextFrame.Text;
                Problem["Note"] = Note.TextFrame.Text;
                Problem["Amount"] = Amount.TextFrame.Text;
                Problem["Date"] = Date.TextFrame.Text;
                Problem["Projects_SameIC"] = Projects_SameIC.TextFrame.Text;
                Problem["Projects_SamePanel"] = Projects_SamePanel.TextFrame.Text;
                Problem["Projects_SameIssueType"] = Projects_SameIssueType.TextFrame.Text;
                Problem["Projects_SameFactory"] = Projects_SameFactory.TextFrame.Text;
                Problem["Issues_SameIC"] = Issues_SameIC.TextFrame.Text;
                Problem["Issues_SamePanel"] = Issues_SamePanel.TextFrame.Text;
                Problem["Issues_SameIssueType"] = Issues_SameIssueType.TextFrame.Text;
                Problem["Issues_SameFactory"] = Issues_SameFactory.TextFrame.Text;
            }
        }
        void LoadTemplate(String IN)
        {
            Presentation test = new Presentation(@IN, FileFormat.Pptx2010);
            ISlide CoverPage = test.Slides[0];
            CoverProcess(CoverPage);
            ISlide PSPage = test.Slides[1];
            ProStaProcess(PSPage);
            TimeLineProcess(PSPage);
            ISlide ProbPage = test.Slides[test.Slides.Count-3];
            ProblemProcss(ProbPage);
            Init = false;
        }
        void SaveCSV()
        {
            using(FileStream fs=new FileStream(".\\Data.csv",FileMode.Append,FileAccess.Write))
            using (TextWriter tw = new StreamWriter(fs, System.Text.Encoding.Default))
            {
                if (!Init)
                {
                    tw.WriteLine();
                }
                else
                {
                    tw.WriteLine("请不要修改表格内容，如需操作请拷贝数据至新文档再操作，谢谢！");
                }
                foreach (KeyValuePair<string, string> kvp in Cover)
                {
                    String Temp = kvp.Value;
                    tw.Write(Temp.Replace("\r"," ").Replace(",","，") + ",");
                }
                foreach (KeyValuePair<string, string> kvp in ProjectStatus)
                {
                    String Temp = kvp.Value;
                    tw.Write(Temp.Replace("\r", " ").Replace(",", "，") + ",");
                }
                foreach (KeyValuePair<string, string> kvp in Problem)
                {
                    String Temp = kvp.Value;
                    tw.Write(Temp.Replace("\r", " ").Replace(",", "，") + ",");
                }
                foreach (KeyValuePair<string, string> kvp in Timeline)
                {
                    String Temp = kvp.Key;
                    if (Init)
                    {
                        tw.Write(Temp.Replace("\n", " ").Replace("\r", " ").Replace(",", "，") + ",");
                        Temp = kvp.Value;
                        tw.Write(Temp.Replace("\n", " ").Replace("\r", " ").Replace(",", "，") + ",");
                    }
                    else
                    {
                        if ((Temp.Equals("时程点") == false))
                        {
                            tw.Write(Temp.Replace("\n", " ").Replace("\r", " ").Replace(",", "，") + ",");
                            Temp = kvp.Value;
                            tw.Write(Temp.Replace("\n", " ").Replace("\r", " ").Replace(",", "，") + ",");
                        }
                    }
                }
            }
        }
        void ProcessOldPPT(String IN)
        {
            Presentation test = new Presentation(@IN, FileFormat.PPT);
            IN = IN.Replace(".ppt", "\\");
            System.IO.Directory.CreateDirectory(IN);
            for(int i = 0; i < test.Slides.Count; i++)
            {
                Image img = test.Slides[i].SaveAsImage();
                img.Save(IN + i + ".bmp");
            }
            Console.WriteLine();
        }
        void DirSeeker()
        {
            for(int i = 0; i < Owners.Length; i++)
            {
                Name[i] = Owners[i].Substring(Owners[i].IndexOf("相关项目ISSUE报告\\")+12);
                FileIterator(Owners[i],Name[i]);
                Console.WriteLine("下一个Owner：");
                Console.WriteLine("");
            }

        }
        void FileIterator(String Path,String Name)
        {
            String[] PPTs = Directory.GetFiles(Path);
            String[] ISSUEs = new String[PPTs.Length];
            Console.WriteLine(Name);
            for(int i=0;i<PPTs.Length;i++)
            {
                ISSUEs[i] = PPTs[i].Substring(PPTs[i].IndexOf(Name)+3);
                Console.WriteLine(ISSUEs[i]);
                NameParser(ISSUEs[i]);
            }
        }
        void NameParser(String FileName)
        {
            String[] Infos = FileName.Split('-');
            foreach(String Info in Infos)
            {
                Console.WriteLine(Info);
            }
        }
        static void Main(string[] args)
        {
            Program P = new Program();

            P.DirSeeker();
            Console.ReadLine();
        }
    }
}
