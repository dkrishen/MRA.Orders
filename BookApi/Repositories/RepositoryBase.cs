using BookApi.Models;

namespace BookApi.Repositories
{
    public class RepositoryBase
    {
        protected MeetingRoomAppBooksContext context;
        public RepositoryBase(MeetingRoomAppBooksContext context)
            => this.context = context;
    }
}
