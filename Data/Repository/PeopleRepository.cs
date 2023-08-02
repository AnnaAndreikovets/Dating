using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Data.Repository
{
    public class PeopleRepository : IPeople
    {
        readonly ApplicationDBContext context;
        
        public PeopleRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        
        public User? PersonForLooking()
        {
            var user = User();
            var attraction = Interaction(user.Id);

            if(attraction is not null)
            {
                var result = Users()?.FirstOrDefault(u => {
                        if(u.Id == User().Id)
                        {
                            return false;
                        }

                        Blank blank = Blank(u.BlankId)!;
                        Blank userBlank = Blank(user.BlankId)!;

                        return (!attraction.UsersAnkets?.Any(a => a.UserId.CompareTo(u.Id) == 0) ?? true) && blank.Sex == userBlank.PreferSex && blank.PreferSex == userBlank.Sex;
                    }
                );

                return result;
            }

            return null;
        }

        public User? PersonForWatching()
        {
            var users = Interested(User().Id)?.Users;

            return users?.Count() > 0 ? User(users.First().UserId) : null;
        }

        public Blank? Blank(Guid id)
        {
            var blanks = Blanks();

            if(blanks is null)
            {
                throw new NullReferenceException("Blanks are empty!");
            }

            return blanks.FirstOrDefault(b => b.Id.CompareTo(id) == 0);
        }

        public IEnumerable<Blank>? Blanks() => context.Blanks;
        
        public Blank CurrentUser() => Blank(User().BlankId)!;

        public IEnumerable<User>? Users() => context.Users;

        public Interested? Interested(Guid userId) => context.Interesteds.Include(i => i.Users).FirstOrDefault(i => i.UserId.CompareTo(userId) == 0);

        public Interaction? Interaction(Guid userId) => context.Interactions.Include(i => i.UsersAnkets).FirstOrDefault(a => a.UserId.CompareTo(userId) == 0);

        public User User() => ApplicationDBContext.User;
    
        public User? User(Guid id) => Users()?.FirstOrDefault(u => u.Id.CompareTo(id) == 0);

        public User? User(string email) => Users()?.FirstOrDefault(p => p.Email == email);
        public User? User(string email, string password) => Users()?.FirstOrDefault(p => p.Email == email && p.Password == password);
    
        public async Task AddUser(User user)
        {
            SetUser(user);

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
        }

        public void SetUser(User user) => ApplicationDBContext.User = user;

        public async Task AddInteractions(Interaction interaction)
        {
            await context.Interactions.AddAsync(interaction);

            await context.SaveChangesAsync();
        }
        
        public async Task AddInterested(Interested interested)
        {
            await context.Interesteds.AddAsync(interested);

            await context.SaveChangesAsync();
        }
        
        public async Task AddBlank(Blank blank)
        {
            await context.Blanks.AddAsync(blank);

            await context.SaveChangesAsync();
        }
        
        public async Task AddAnket(Interaction interaction, Guid id)
        {   
            if(interaction.UsersAnkets is null)
            {
                interaction.UsersAnkets = new List<Anket>();
            }

            Anket anket = new Anket()
            {
                Id = Guid.NewGuid(),
                UserId = id
            };

            await context.AddAsync(anket);

            interaction.UsersAnkets.Add(anket);

            await context.SaveChangesAsync();
        }

        public async Task AddInterested(Interested interested, Guid id, Guid userId)
        {
            if(interested.Users is null)
            {
                interested.Users = new List<InterestedUser>();
            }

            InterestedUser interestedUser = new InterestedUser()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            await context.InterestedUsers.AddAsync(interestedUser);

            interested.Users.Add(interestedUser);

            await context.SaveChangesAsync();
        }

        public Anket? Anket(Guid id) => Interaction(User().Id)?.UsersAnkets?.FirstOrDefault(a => a.Id.CompareTo(id) == 0);

        public Anket? Anket(Guid userId, Guid secondId) => Interaction(userId)?.UsersAnkets?.FirstOrDefault(a => a.UserId == secondId);

        public async Task RemoveInterestedUser(Guid id)
        {
            var users = Interested(User().Id)?.Users;

            if(users is null)
            {
                throw new ArgumentNullException("Invalid user data!");
            }

            var interestedUser = users.FirstOrDefault(u => u.UserId.CompareTo(id) == 0);

            if(interestedUser is null)
            {
                throw new ArgumentNullException("Invalid id for interestedUser!");
            }

            users.Remove(interestedUser);

            await context.SaveChangesAsync();
        }
    }
}