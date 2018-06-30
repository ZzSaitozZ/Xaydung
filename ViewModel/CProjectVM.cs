using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Xaydung.ViewModel
{
    public class CProjectVM
    {
        public List<CProject> projects { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}