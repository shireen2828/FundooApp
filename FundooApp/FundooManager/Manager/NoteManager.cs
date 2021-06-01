using FundooManager.Interfaces;
using FundooModel;
using FundooRepository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FundooManager.Manager
{
    public class NoteManager : INoteManager
    {
        private readonly INoteRepository repository;

        public NoteManager(INoteRepository repository)
        {
            this.repository = repository;
        }

        public bool AddNotes(NotesModel model)
        {
            try
            {
                bool result = this.repository.AddNotes(model);
                return result;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NotesModel RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel notes = this.repository.RetrieveNotesById(noteId);
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool RemoveNote(int noteId)
        {
            try
            {
                bool result = this.repository.RemoveNote(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string UpdateNotes(NotesModel model)
        {
            try
            {
                string result = this.repository.UpdateNotes(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Pin(int noteId)
        {
            try
            {
                string result = this.repository.Pin(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Unpin(int noteId)
        {
            try
            {
                string result = this.repository.Unpin(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                string result = this.repository.ArchieveOrUnarchieve(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string TrashorUntrash(int noteId)
        {
            try
            {
                string result = this.repository.ArchieveOrUnarchieve(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Color(string color, int noteId)
        {
            try
            {
                bool result = this.repository.Color(color, noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool AddReminder(int noteId, string reminder)
        {
            try
            {
                bool result = this.repository.AddReminder(noteId, reminder);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetReminder()
        {
            try
            {
                IEnumerable<NotesModel> notes = this.repository.GetReminder();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetNote(int userId)
        {
            try
            {
                IEnumerable<NotesModel> notes = this.repository.GetNote(userId);
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UploadImage(int noteId, IFormFile image)
        {
            try
            {
                bool result = this.repository.UploadImage(noteId, image);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}