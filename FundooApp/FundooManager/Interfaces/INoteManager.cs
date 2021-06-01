using FundooModel;
using FundooModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface INoteManager
    {
        public bool AddNotes(NotesModel model);
        public NotesModel RetrieveNotesById(int noteId);
        public bool RemoveNote(int noteId);
        public string UpdateNotes(NotesModel model);
        public string Pin(int id);
        public string Unpin(int id);
        public string ArchieveOrUnarchieve(int id);
        public string TrashorUntrash(int noteId);
        public bool Color(string color, int noteId);
        public bool AddReminder(int id, string reminder);
        public IEnumerable<NotesModel> GetReminder();
        public IEnumerable<NotesModel> GetNote(int userId);
        public bool UploadImage(int noteId, IFormFile image);
    }
}
