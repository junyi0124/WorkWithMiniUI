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
    }

    public class SPS_Test
    {
        public void main()
        {
            var tree = new SpanningTreeService<MaterialEntity>();

        }

    }
}
