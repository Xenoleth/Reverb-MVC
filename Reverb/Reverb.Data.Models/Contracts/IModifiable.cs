using System;

namespace Reverb.Data.Models.Contracts
{
    public interface IModifiable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
