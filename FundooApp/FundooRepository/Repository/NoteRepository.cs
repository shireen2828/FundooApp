// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//---------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModel;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    /// <summary>
    /// class for note repository
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        /// <summary>
        /// private method for user context and configuration
        /// </summary>
        private UserContext userContext;
        private IConfiguration configuration;

        /// <summary>
        /// method for Note repository
        /// </summary>
        /// <param name="userContext"></user context>
        /// <param name="configuration"></configuration>
        public NoteRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// method for add notes
        /// </summary>
        /// <param name="Model"></model>
        /// <returns></returns>
        public bool AddNotes(NotesModel Model)
        {
            try
            {
                if (Model != null)
                {
                    this.userContext.Notes.Add(Model);
                    var notes = this.userContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for retrieve notes
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public NotesModel RetrieveNotesById(int noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    NotesModel notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                    return notes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for Remove note
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public bool RemoveNote(int noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                    if (notes != null)
                    {
                        if (notes.isTrash == true)
                        {
                            this.userContext.Notes.Remove(notes);
                            this.userContext.SaveChangesAsync();
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for update note
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        public string UpdateNotes(NotesModel model)
        {
            try
            {
                if (model.NoteId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }

                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for pin note
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public string Pin(int noteId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Pin == false)
                {
                    notes.Pin = true;
                    this.userContext.Entry(notes).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    string message = "Note is getting pin";
                    return message;
                }

                return "Unable to Pin  notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for unpin
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public string Unpin(int noteId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Pin == false)
                {
                    notes.Pin = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note Unpinned";
                    return message;
                }

                return "Unable to  Unpin notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for archive or unarchive
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public string ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Archive == false)
                {
                    notes.Archive = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is Archieve";
                    return message;
                }
                if (notes.Archive == true)
                {
                    notes.Archive = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note UnArchieve";
                    return message;
                }

                return "Unable to Archieve or UnArchieve notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for trash or untrash
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public string TrashorUntrash(int noteId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Archive == false)
                {
                    notes.Archive = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is Trash";
                    return message;
                }

                if (notes.Archive == true)
                {
                    notes.Archive = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is UnTrash";
                    return message;
                }

                return "Unable to Trash or Untrash notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for color
        /// </summary>
        /// <param name="color"></color>
        /// <param name="noteId"></noteId>
        /// <returns></returns>
        public bool Color(string color, int noteId)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes != null && notes.isTrash == false)
                {
                    notes.Color = color;
                    this.userContext.Notes.Update(notes);
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for add reminder
        /// </summary>
        /// <param name="noteId"></note Id>
        /// <param name="reminder"></reminder>
        /// <returns></returns>
        public bool AddReminder(int noteId, string reminder)
        {
            try
            {
                var notes = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (notes != null)
                {
                    notes.Reminder = reminder;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for get reminder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotesModel> GetReminder()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Notes.Where(x => x.Reminder.Length > 0);
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for get note
        /// </summary>
        /// <param name="userId"></userId>
        /// <returns></returns>
        public IEnumerable<NotesModel> GetNote(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Notes;
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method for upload image
        /// </summary>
        /// <param name="noteId"></noteId>
        /// <param name="image"></image>
        /// <returns></returns>
        public bool UploadImage(int noteId, IFormFile image)
        {
            try
            {
                var note = this.userContext.Notes.Where(p => p.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    Account account = new Account(
                        configuration["CloudinaryAccount:CloudName"],
                        configuration["CloudinaryAccount:ApiKey"],
                        configuration["CloudinaryAccount:ApiSecret"]
                    );
                    var path = image.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    note.Image = uploadResult.Url.ToString();
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}