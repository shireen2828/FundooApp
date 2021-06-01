using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface ILabelManager
    {
        public bool AddLabel(LabelModel model);
        public string UpdateLabel(LabelModel model);
        public bool RemoveLabel(int labelId);
        public IEnumerable<LabelModel> GetLabel(int noteId);
        public LabelModel GetLabelbyId(int userId);
    }
}
