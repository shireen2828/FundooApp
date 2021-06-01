using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    {
        public bool AddLabel(LabelModel model);
        public string UpdateLabel(LabelModel model);
        public bool RemoveLabel(int labelId);
        public IEnumerable<LabelModel> GetLabel(int noteId);
        public LabelModel GetLabelbyId(int userId);
    }
}
