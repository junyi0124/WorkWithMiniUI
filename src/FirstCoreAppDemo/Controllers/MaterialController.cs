using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstCoreAppDemo.Data;
using FirstCoreAppDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreAppDemo.Controllers
{
    public class MaterialController : Controller
    {
        private ApplicationDbContext _ctx;

        public MaterialController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Produces("application/json")]
        public async Task<MiniUiPageTreeRespond<MaterialEntity>> GetMaterials(string key = "",
            int pageIndex = 0, int pageSize = 20,
            string __ecconfig = "")
        {
            // 获取节点总数
            var nodeCount = await _ctx.Materials.CountAsync();

            // 处理折叠
            if(!string.IsNullOrWhiteSpace(__ecconfig))
            {
                var nodeEcConfig = (System.Collections.Hashtable)FromMiniUI.JSON.Decode(__ecconfig);
                var nodeList = nodeEcConfig["collapseNodes"] as System.Collections.ArrayList;
                if (nodeList!=null && nodeList.Count > 0)
                {
                    foreach (var item in nodeList)
                    {
                        
                    }
                }
            }

            // 生成最终数据
            List<MaterialEntity> data;
            var query = _ctx.Materials.AsQueryable();
            if (!string.IsNullOrWhiteSpace(key))
                query = query.Where(m => m.Code.Contains(key) || m.FullName.Contains(key));

            data = await query.OrderBy(m => m.SortNumber)
                .Skip(pageIndex * pageSize).Take(pageSize)
                .ToListAsync();

            //data.Add(new MaterialEntity {

            //});
            MiniUiPageTreeRespond<MaterialEntity> json = new MiniUiPageTreeRespond<MaterialEntity>();
            json.data = data;
            json.allIds = new List<string> { "0300000099000000", "1000000060004318" };
            json.total = nodeCount;
            return json;
        }
    }
}