using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTST.UiPath.Orchestrator.Models
{
    public interface IUipathResponseMultiple<T> where T : IUipathResponseSingle
    {
        public T[] Value { get; set; }
        public long OdataCount { get; set; }
    }

    public interface IUipathResponseSingle
    {
        public long Id { get; set; }
    }
}
