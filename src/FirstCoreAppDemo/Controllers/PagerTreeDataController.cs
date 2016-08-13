using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FirstCoreAppDemo.Controllers
{
    //[Produces("application/json")]
    public class PagerTreeDataController : Controller
    {
        public ContentResult Index(string key="", int pageIndex=0, int pageSize=20)
        {
            //��ȡ�б����ݣ�����
            ArrayList treelist = FromDataBase();

            //ʹ��PagerTree����˷�ҳ����
            var tree = new FromMiniUI.DataTree("UID", "ParentTaskUID", "children");
            tree.LoadList(treelist);

            //�����۵�
            tree.SetRequest(Request);

            //�������
            if (!string.IsNullOrEmpty(key))
            {
                ArrayList nodes = SearchNodes(key, treelist);
                tree.SetFiltered(nodes);
            }

            //�����ҳ
            Hashtable result = new Hashtable();
            result["total"] = tree.GetTotalCount();
            result["data"] = tree.GetPagedData(pageIndex, pageSize);

            //�������и��ڵ�
            ArrayList allIds = new ArrayList();
            for (int i = 0, l = treelist.Count; i < l; i++)
            {
                Hashtable node = (Hashtable)treelist[i];
                if (node["children"] != null) allIds.Add(node["UID"]);
            }
            result["allIds"] = allIds;

            //����JSON
            String json = FromMiniUI.JSON.Encode(result);
            return Content(json);
        }

        private ArrayList FromDataBase()
        {
            // ���ػ��� ���idû�б�ʹ��
            string id = Request.Query["id"];

            //ʾ���ӱ����ļ���ȡ��ʵ��Ӧ�ô����ݿ��ȡ��������
            string path = MapPath("tasks.txt");
            //��ȡ�ļ�����
            string json = FromMiniUI.File.Read(path);
            //ͨ����̬������ʽ������
            ArrayList tree = (ArrayList)FromMiniUI.JSON.Decode(json);
            return tree;
        }

        private ArrayList SearchNodes(string key, ArrayList nodeList)
        {
            key = key.ToLower();
            ArrayList filters = new ArrayList();

            for (int i = 0, l = nodeList.Count; i < l; i++)
            {
                Hashtable node = (Hashtable)nodeList[i];
                string taskName = node["Name"] != null ? node["Name"].ToString().ToLower() : "";
                if (taskName.IndexOf(key) != -1)
                {
                    filters.Add(node);
                }
            }

            return filters;
        }

        private string MapPath(string v)
        {
            //todo �˴�û��ʹ�ö�̬��ȡ���Ժ���ʱ�����޸��������
            return $@"D:\johns\Documents\Visual Studio 2015\Projects\FirstCoreAppDemo\src\FirstCoreAppDemo\wwwroot\js\{v}";
        }
    }
}
