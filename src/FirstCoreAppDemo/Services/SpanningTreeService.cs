using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreAppDemo.Models;

namespace FirstCoreAppDemo.Services
{
    public class SpanningTreeService<T>
    {
        private HashSet<T> _data;
        private readonly string _idField = "id";
        private readonly string _pidField = "pid";
        private readonly string _nodesField = "children";

        private readonly string rootId = "-1";
        private readonly string leafField = "isLeaf";
        private readonly string levelField = "_level";
        private readonly string expandedField = "expanded";

        public SpanningTreeService()
        {
            _data = new HashSet<T>();
        }

        public SpanningTreeService(string idField, string pidField, string nodesField)
            :this()
        {
            _idField = idField;
            _pidField = pidField;
            _nodesField = nodesField;
        }

        public MiniUiPageTreeRespond<T> ToTree(string term = "",
            string __ecconfig = "",
            int pageIndex = 0,
            int pageSize = 20)
        {
            MiniUiPageTreeRespond<T> json = new MiniUiPageTreeRespond<T>();

            // 查询，折叠，获取部分数据

            // 转换为Hashset

            // 返回父节点


            // 返回json
            //json.total = ;
            //json.data = Data;
            //json.allIds = ;
            return json;
        }
    }

    public class SPS_Test
    {
        public void main()
        {
            var tree = new SpanningTreeService<MaterialEntity>();
            //tree.ToTree("",)
        }

    }
}
