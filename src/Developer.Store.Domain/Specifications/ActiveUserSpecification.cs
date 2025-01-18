using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Enums;

namespace Developer.Store.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
