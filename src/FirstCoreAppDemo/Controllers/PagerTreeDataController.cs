using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.AspNetCore.Hosting;

namespace FirstCoreAppDemo.Controllers
{
    //[Produces("application/json")]
    public class PagerTreeDataController : Controller
    {
        private IHostingEnvironment _env;

        public PagerTreeDataController(IHostingEnvironment env)
        {
            _env = env;
        }

        public ContentResult Index(string key = "", int pageIndex = 0, int pageSize = 20, string __ecconfig = "")
        {
            //获取列表数据（树）
            ArrayList treelist = FromDataBase();

            //使用PagerTree服务端分页功能
            var tree = new FromMiniUI.DataTree("UID", "ParentTaskUID", "children");
            tree.LoadList(treelist);

            //处理折叠
            tree.SetRequest(__ecconfig);

            //处理过滤
            if (!string.IsNullOrEmpty(key))
            {
                ArrayList nodes = SearchNodes(key, treelist);
                tree.SetFiltered(nodes);
            }

            //处理分页
            Hashtable result = new Hashtable();
            result["total"] = tree.GetTotalCount();
            result["data"] = tree.GetPagedData(pageIndex, pageSize);

            //返回所有父节点
            ArrayList allIds = new ArrayList();
            for (int i = 0, l = treelist.Count; i < l; i++)
            {
                Hashtable node = (Hashtable)treelist[i];
                if (node["children"] != null) allIds.Add(node["UID"]);
            }
            result["allIds"] = allIds;

            //返回JSON
            String json = FromMiniUI.JSON.Encode(result);
            return Content(json);
        }

        private ArrayList FromDataBase()
        {
            // 严重怀疑 这个id没有被使用
            string id = Request.Query["id"];

            //示例从本地文件读取，实际应该从数据库获取树型数据
            string path = MapPath("tasks.txt");
            //读取文件内容
            string json = FromMiniUI.File.Read(path);
            //通过静态方法格式化数据
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
            var resPath = _env.ContentRootPath + "\\wwwroot\\js\\{0}";
            //todo 此处没有使用动态获取，以后有时间再修复这个功能
            return string.Format(resPath, v);
        }
    }
}
