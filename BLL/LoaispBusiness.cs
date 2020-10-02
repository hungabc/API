using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class LoaispBusiness : ILoaispBusiness
    {
        private ILoaispRepository _res;
        public LoaispBusiness(ILoaispRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<LoaispModel> GetCha()
        {
            var allItemGroups = _res.GetDataAll();
            var lstParent = allItemGroups.Where(ds => ds.PARENTID == null).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<LoaispModel> GetHiearchyList(List<LoaispModel> lstAll, LoaispModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.PARENTID == node.PARENTID).ToList();

            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.ToList();
        }
    }

}
