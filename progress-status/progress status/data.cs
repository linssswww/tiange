using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace progress_status
{
    public struct Employ
    {
        public string employName;
    };
    public struct XmlInfo
    {
        public string username;
        public string writetime;
        public string segmented;

    }

    public class Data
    {
        public Data() { }
        public List<Employ> getUserList()
        {
            Employ employ = new Employ();
            employ.employName = "员工1";

            Employ employ1 = new Employ();
            employ1.employName = "员工2";

            Employ employ2 = new Employ();
            employ2.employName = "员工3";

            Employ employ3 = new Employ();
            employ3.employName = "员工4";

            Employ employ4 = new Employ();
            employ4.employName = "员工5";
            List<Employ> list = new List<Employ>();
            list.Add(employ);
            list.Add(employ1);
            list.Add(employ2);
            list.Add(employ3);
            list.Add(employ4);
            return list;
        }
        public void addUser(string usrnm, string usrpsw)
        {
            
        }
        public void getXmlPathList()
        {

        }
        public void getPicPathList()
        {

        }
        public int calGroups()
        {
            return 0;
        }
        public void getNamePath()//获取当天的时间.
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\image";

            if (!Directory.Exists(path))
                throw new Exception("无法找到文件夹：line 66, locate getPath");

            m_namePath = path;
            //DirectoryInfo theFolder = new DirectoryInfo(path);

            //string tm = DateTime.Now.ToString("yyMMdd");
            //path = path + "\\" + tm;
            //if (!Directory.Exists(path))
            //    throw new Exception("无法找到文件夹：" + path);

        }
        public List<string> getDirtorys(String path)
        {
            List<string> dirs = new List<string>();
            DirectoryInfo rootDirs = new DirectoryInfo(path);
            foreach (DirectoryInfo d in rootDirs.GetDirectories())
            {
                dirs.Add(d.FullName);
            }

            if (dirs.Count == 0)
                throw new Exception("当前目录无下无子目录");

            return dirs;
        }

        private string getCurrentDayDir(string name, string tim)
        {
            string path = "./image/" + name + "/" + tim;
            return path;
        }
        private int getFiles(string path, string format)
        {
            DirectoryInfo rootDir = new DirectoryInfo(path);
            int num = 0;
            foreach (FileInfo f in rootDir.GetFiles())
            {
                if (f.Name.Contains(format))
                    num++;
            }
            return num;
        }

        public List<string> getXmlPaths(string usernm, string tim, int days)
        {
            DateTime time = new DateTime();
            tim = "20" + tim;
            time = DateTime.Parse(tim);

            

            string year;
           // time.Day = tim.ElementAt
            return null;
        }
        //获取所有目录的路径
        public void GetAllDirList(string strBaseDir)
        {
            DirectoryInfo di = new DirectoryInfo(strBaseDir);
            DirectoryInfo[] diA = di.GetDirectories();
            for (int i = 0; i < diA.Length; i++)
            {
                m_xmlList.Add(diA[i].FullName);
                //diA[i].FullName是某个子目录的绝对地址，把它记录在ArrayList中
                GetAllDirList(diA[i].FullName);
            }
        }
        public void getXmlPaths()
        {
            string path = "./image";
            GetAllDirList(path);
            foreach(var str in m_xmlList)
            {
                DirectoryInfo dir = new DirectoryInfo(str);
                foreach(var filexml in dir.GetFiles(".xml"))
                {
                    m_fullXML.Add(filexml.FullName);
                }
            }
        }
        public void decodeXml()
        {
            foreach(var path in m_fullXML)
            {
                XmlInfo singlexml;
                var xdoc = new System.Xml.XmlDocument();
                xdoc.Load(path);
                XmlNode xNode = xdoc.SelectSingleNode("username");
                singlexml.username = xNode.InnerText;

                XmlNode xNode1 = xdoc.SelectSingleNode("writetime");
                singlexml.writetime = xNode1.InnerText;

                XmlNode xNode2 = xdoc.SelectSingleNode("segmented");
                singlexml.segmented = xNode2.InnerText;
                m_fullXMLInfo.Add(singlexml);
            }
        }
        public List<XmlInfo> filterXml(string format) // format = name|writetime 
        {
            
            List<XmlInfo> muti = new List<XmlInfo>();
            foreach(var filexml in m_fullXMLInfo)
            {
                string info = filexml.username + "|" + filexml.writetime;
                if(info.Contains(format))
                    muti.Add(filexml);
            }
            if (muti.Count == 0)
                throw new Exception("原因:xml文件数量为0，filterXml");
            return muti;
        }
        /***********************************************************************/
        /************************************************************************/
        public int getImagesNum(string name, string tim)//拍照数量
        {
            //获取当天的对应人当天的
            //string getCurrentDayDir(string name, string tim)
            //获取当前文件夹.jpg文件数量
            //int getFiles(string path, string format)
            //
            /******************************************************/
            string path = getCurrentDayDir(name, tim);
            int num = getFiles(path, ".jpg");
            return num;
        }
        public void getImagesSidesNum(string name, string tim)//商品面数
        {

        }
        public int getImageGroups(string name, string tim)//获取拍照组数
        {
            //获取当天文件夹
            //string getCurrentDayDir(string name, string tim)
            //string dapath = currentDir + “\\dan”;
            //string dupath = currentDir + "\\duo";

            //获取当前路径下的文件夹路径
            //List<string> getDirs(string path);
            //获取文件夹下的文件数量
            //int getFiles(string path, string format)
            /*
             string currentDir = getCurrentDayDir()
             string dapath = currentDir + "dan"
             string dupath = currentDir + "duo"

            List du = getDirs(dapath);
            List da = getDirs(dupath);
             */

            string currentDir = getCurrentDayDir(name, tim);
            string dapath = currentDir + "\\dan";
            string dupath = currentDir + "\\duo";

            List<string> duDir = getDirtorys(dapath);
            List<string> daDir = getDirtorys(dupath);

            int dunum = 0, danum = 0;
            foreach (string path in duDir)
            {
                if (getFiles(path, ".jpg") > 0)
                    dunum++; 
            }

            foreach(string path in daDir)
            {
                if (getFiles(path, ".jpg") > 0)
                    danum++;
            }

            return danum + dunum;
        }
        public int getDealImageNum(string usernm, string yyyyMMdd)//打标签图片数量(打标签名字， 时间)
        {

            //获取五天内的文件夹路径下所有的xml文件路径
            //List <string>getXmlPaths()
            // decodexml(XMLDocument []);-->> xmlinfo {string name, int Rects ,string path , string tim}
            // 过滤时间不一样的和 名字不一样的
            // filterXml（xmlinfo）;
            /*************************************************************/

            //getXmlPaths();
            //decodeXml();
            DateTime dt = DateTime.ParseExact(yyyyMMdd, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string yyyy_MM_dd = dt.ToString("yyyy-MM-dd");
            string format = usernm + "|" + yyyy_MM_dd;
            List<XmlInfo> filerresult = filterXml(format);

            return filerresult.Count;
        }
        public int getDealImageRects(string usernm, string yyyyMMdd)//图片框数
        {
            DateTime dt = DateTime.ParseExact(yyyyMMdd, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string yyyy_MM_dd = dt.ToString("yyyy-MM-dd");
            string format = usernm + "|" + yyyy_MM_dd;
            List<XmlInfo> filerresult = filterXml(format);
            int num = 0;
            foreach(var single in filerresult)
            {
                num = num + Convert.ToInt16(single.segmented);
            }
            return num;
        }
        public void getDealImageGroups(string name, string tim)
        {
            // 根据过滤的， 今天计算了多少组
            // int calGroups(xmlinfo)
        }
        private string m_namePath;
        private List<string> m_xmlList = new List<string>();
        private List<string> m_fullXML = new List<string>();
        private List<XmlInfo> m_fullXMLInfo = new List<XmlInfo>();
        
    }
}
