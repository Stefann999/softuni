using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Core.Models;
using SeminarHub.Core.Services.Contracts;
using SeminarHub.Data;
using SeminarHub.Data.Entities;
using System.Globalization;
using static SeminarHub.Common.EntityValidationsConstants.Seminar;

namespace SeminarHub.Core.Services
{
    [Authorize]
    public class SeminarService : ISeminarService
    {
        private readonly SeminarHubDbContext dbContext;

        public SeminarService(SeminarHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoryTypesAsync()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task AddSeminarAsync(SeminarFormModel model)
        {
            var seminar = new Seminar
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                OrganizerId = model.OrganizerId,
                DateAndTime = (DateTime.ParseExact(model.DateAndTime, DateTimeFormat, CultureInfo.InvariantCulture)),
                Duration = model.Duration,
                CategoryId = model.CategoryId
            };

            await dbContext.Seminars.AddAsync(seminar);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SeminarViewModel>> GetAllSeminarsAsync()
        {
            var seminars = await dbContext.Seminars
             .Select(e => new SeminarViewModel
             {
                 Id = e.Id,
                 Topic = e.Topic,
                 Lecturer = e.Lecturer,
                 OrganizerId = e.OrganizerId,
                 Organizer = e.Organizer,
                 CategoryId = e.CategoryId,
                 Category = e.Category.Name,
                 DateAndTime = e.DateAndTime.ToString(DateTimeFormat)
             })
             .ToListAsync();

            return seminars;
        }

        public async Task<IEnumerable<SeminarViewModel>> GetAllJoinedSeminarsAsync(string userId)
        {
            var joinedSeminars = await dbContext.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .AsNoTracking()
                .Select(e => new SeminarViewModel
                {
                    Id = e.Seminar.Id,
                    Topic = e.Seminar.Topic,
                    Lecturer = e.Seminar.Lecturer,
                    OrganizerId = e.Seminar.OrganizerId,
                    Organizer = e.Seminar.Organizer,
                    CategoryId = e.Seminar.CategoryId,
                    Category = e.Seminar.Category.Name,
                    DateAndTime = e.Seminar.DateAndTime.ToString(DateTimeFormat)
                })
                .ToListAsync();

            return joinedSeminars;
        }

        public async Task<SeminarFormModel> GetSeminarByIdAsync(int id)
        {
            var seminarById = await dbContext.Seminars.FindAsync(id);

            if (seminarById != null)
            {
                SeminarFormModel seminarFormModel = new()
                {
                    Topic = seminarById.Topic,
                    Lecturer = seminarById.Lecturer,
                    Details = seminarById.Details,
                    OrganizerId = seminarById.OrganizerId,
                    DateAndTime = seminarById.DateAndTime.ToString(DateTimeFormat),
                    Duration = seminarById.Duration,
                    CategoryId = seminarById.CategoryId
                };

                return seminarFormModel;
            }

            return null;
        }

        public async Task EditSeminarAsync(int id, SeminarFormModel model)
        {
            var seminarToEdit = await dbContext.Seminars.FindAsync(id);

            if (seminarToEdit != null)
            {
                seminarToEdit.Topic = model.Topic;
                seminarToEdit.Lecturer = model.Lecturer;
                seminarToEdit.Details = model.Details;
                seminarToEdit.DateAndTime = (DateTime.ParseExact(model.DateAndTime, DateTimeFormat, CultureInfo.InvariantCulture));
                seminarToEdit.Duration = model.Duration;
                seminarToEdit.CategoryId = model.CategoryId;
                seminarToEdit.OrganizerId = model.OrganizerId;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task AddSeminarToJoinedSeminarsAsync(string userId, int seminarId)
        {
            SeminarParticipant seminarParticipant = new SeminarParticipant()
            {
                ParticipantId = userId,
                SeminarId = seminarId
            };

            if (!dbContext.SeminarsParticipants.Contains(seminarParticipant))
            {
                await dbContext.SeminarsParticipants.AddAsync(seminarParticipant);

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveSeminarFromJoinedSeminarsAsync(string userId, int seminarId)
        {
            var seminarToRemove = await dbContext.SeminarsParticipants
                .Where(ep => ep.ParticipantId == userId && ep.SeminarId == seminarId)
                .FirstOrDefaultAsync();

            if (seminarToRemove != null)
            {
                dbContext.SeminarsParticipants.Remove(seminarToRemove);

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<SeminarDetailsViewModel> GetSeminarDetailsByIdAsync(int id)
        {
            var seminarDetails = await dbContext.Seminars
                .Where(e => e.Id == id)
                .Select(e => new SeminarDetailsViewModel
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Lecturer = e.Lecturer,
                    Details = e.Details,
                    DateAndTime = e.DateAndTime.ToString(DateTimeFormat),
                    Duration = e.Duration.Value,
                    CategoryId = e.CategoryId,
                    Category = e.Category.Name,
                    OrganizerId = e.OrganizerId,
                    Organizer = e.Organizer
                })
                .FirstOrDefaultAsync();

            return seminarDetails;
        }

        public async Task<SeminarDeleteViewModel> GetSeminarForDeleteByIdAsync(int id)
        {
            var seminar = await dbContext.Seminars.FirstOrDefaultAsync(s => s.Id == id);

            if (seminar != null)
            {
                SeminarDeleteViewModel seminarForDelete = new SeminarDeleteViewModel()
                {
                    Id = seminar.Id,
                    Topic = seminar.Topic,
                    DateAndTime = seminar.DateAndTime.ToString(DateTimeFormat),
                    OrganizerId = seminar.OrganizerId
                };

                return seminarForDelete;
            }

            return null;
        }

        public async Task DeleteSeminarAsync(int id)
        {
            var seminarToDelete = await dbContext.Seminars.FindAsync(id);

            foreach (var seminarParticipant in dbContext.SeminarsParticipants)
            {
                if (seminarParticipant.SeminarId == id)
                {
                    dbContext.SeminarsParticipants.Remove(seminarParticipant);
                }
            }

            if (seminarToDelete != null)
            {
                dbContext.Seminars.Remove(seminarToDelete);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
