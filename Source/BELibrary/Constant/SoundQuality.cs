using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BELibrary.Models;

namespace BELibrary.Constant
{
    public static class SoundQuality
    {
        public static List<ItemModel> Datas = new List<ItemModel>
            {new ItemModel {Name = "Minimum", Value = 0}, new ItemModel {Name = "Trung bình", Value = 0}, new ItemModel {Name = "Maximum", Value = 0}};
    }
}
