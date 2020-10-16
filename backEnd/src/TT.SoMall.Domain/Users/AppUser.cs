using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace TT.SoMall.Users
{
    /* This entity shares the same table/collection ("AbpUsers" by default) with the
     * IdentityUser entity of the Identity module.
     *
     * - You can define your custom properties into this class.
     * - You never create or delete this entity, because it is Identity module's job.
     * - You can query users from database with this entity.
     * - You can update values of your custom properties.
     */
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        private AppUser()
        {
        }

        /* Add your own properties here. Example:
         *
         * public virtual string MyProperty { get; set; }
         */

        public virtual string Nickname { get; set; }
        public virtual string HeadImgUrl { get; set; }

        public void SetPhone(string phone)
        {
            if (!phone.IsNullOrWhiteSpace())
            {
                PhoneNumber = phone;
                PhoneNumberConfirmed = true;
            }
        }

        public void SetEmail(string email)
        {
            if (!email.IsNullOrWhiteSpace())
            {
                Email = email;
                EmailConfirmed = false;
            }
        }

        public void SetName(string name)
        {
            if (!name.IsNullOrWhiteSpace())
            {
                Name = name;
            }
        }

        public void SetUserName(string username)
        {
            if (!username.IsNullOrWhiteSpace())
            {
                UserName = username;
            }
        }

        public void SetSurname(string surname)
        {
            if (!surname.IsNullOrWhiteSpace())
            {
                Surname = surname;
            }
        }

        #region Base properties

        /* These properties are shared with the IdentityUser entity of the Identity module.
         * Do not change these properties through this class. Instead, use Identity module
         * services (like IdentityUserManager) to change them.
         * So, this properties are designed as read only!
         */

        public virtual Guid? TenantId { get; private set; }

        public virtual string UserName { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string Surname { get; private set; }

        public virtual string Email { get; private set; }

        public virtual bool EmailConfirmed { get; private set; }

        public virtual string PhoneNumber { get; private set; }

        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion
    }
}