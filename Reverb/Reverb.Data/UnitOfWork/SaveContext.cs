using Reverb.Data.Contracts;

namespace Reverb.Data.SaveChanges
{
    public class SaveContext : ISaveContext
    {
        private readonly IReverbDbContext context;

        public SaveContext(IReverbDbContext context)
        {
            //Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
