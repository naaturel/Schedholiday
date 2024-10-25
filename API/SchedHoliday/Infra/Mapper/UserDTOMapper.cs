using SchedHoliday.Models;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra.Mapper
{
    public class UserDTOMapper : IMapper<User, DTOUser>
    {
        public User? From(DTOUser src)
        {
            if (src == null) return null;

            return new User
            {
                Id = src.Id,
                FirstName = src.FirstName,
                LastName = src.LastName,
                Email = src.Email,
                Password = src.Password
            };
        }

        public DTOUser From(User src)
        {
            return new DTOUser
            {
                Id = src.Id,
                FirstName = src.FirstName,
                LastName = src.LastName,
                Email = src.Email,
                Password = src.Password
            };
        }

        public IEnumerable<User> FromMany(IEnumerable<DTOUser> src)
        {
            var users = new List<User>();

            foreach (var dtoU in src)
            {
                users.Add(From(dtoU));

            }

            return users;

        }

        public IEnumerable<DTOUser> FromMany(IEnumerable<User> src)
        {
            var users = new List<DTOUser>();

            foreach (var dtoU in src)
            {
                users.Add(From(dtoU));

            }

            return users;
        }
    }



    /*public IEnumerable<TRG_T> FromMany(IEnumerable<SRC_T> vms)
    {

        if (vms == null) return default;

        var r = new List<TRG_T>();

        foreach (SRC_T vm in vms)
        {
            r.Add(From(vm));
        }

        return r;
    }

    public TRG_T From(SRC_T src)
    {

        if (src == null) return default;

        TRG_T trg = new TRG_T();

        var srcProps = typeof(SRC_T).GetProperties(); //Get properties of source type


        foreach (var srcProp in srcProps)
        {

            var trgProp = typeof(TRG_T).GetProperty(srcProp.Name); //Get the corresponding property of target type
            var trgVal = srcProp.GetValue(src); //Get the value of the current source property

            //If target property is null, no corresponding properties have been found
            if (trgProp != null)
            {
                //If the source property has the same type as the target property
                if (srcProp.PropertyType == trgProp.PropertyType)
                {
                    trgProp.SetValue(trg, trgVal);
                }
                //It is propably a string
                else if(trgVal != null)
                {
                    trgProp.SetValue(trg, trgVal.ToString());
                }
            }
        }

        return trg;

    }*/
}
