using NUnit.Framework;
using SchedHoliday.Infra;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Tests
{
    public class DTOMapperTests
    {


        /*[Test]
        public void same_object_same_attribtues()
        {

            DTOHoliday dtoH = new DTOHoliday
            {
                Id = "this is an id",
                Name = "this is a name",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Longitude = 42,
                Latitude = 12,
            };

            HolidayViewModelGet vmH = new HolidayViewModelGet
            {
                Id = "this is an id",
                Name = "this is a name",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Longitude = 42,
                Latitude = 12,
            };

            var newVm = DTOMapper<HolidayViewModelGet, DTOHoliday>.From(dtoH);
            var newDto = DTOMapper<DTOHoliday, HolidayViewModelGet>.From(vmH);

            Assert.That(newVm.Id, Is.EqualTo(dtoH.Id));
            Assert.That(newVm.Name, Is.EqualTo(dtoH.Name));
            Assert.That(newVm.StartDate, Is.EqualTo(dtoH.StartDate));
            Assert.That(newVm.EndDate, Is.EqualTo(dtoH.EndDate));
            Assert.That(newVm.Longitude, Is.EqualTo(dtoH.Longitude));
            Assert.That(newVm.Latitude, Is.EqualTo(dtoH.Latitude));

            Assert.That(newDto.Id, Is.EqualTo(vmH.Id));
            Assert.That(newDto.Name, Is.EqualTo(vmH.Name));
            Assert.That(newDto.StartDate, Is.EqualTo(vmH.StartDate));
            Assert.That(newDto.EndDate, Is.EqualTo(vmH.EndDate));
            Assert.That(newDto.Longitude, Is.EqualTo(vmH.Longitude));
            Assert.That(newDto.Latitude, Is.EqualTo(vmH.Latitude));

        }

        [Test]
        public void same_object_missing_attribtues()
        {

            DTOHoliday dtoH = new DTOHoliday
            {
                Id = "this is an id",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
            };

            HolidayViewModelGet vmH = new HolidayViewModelGet
            {
                Id = "this is an id",
                Name = "this is a name",
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Longitude = 42,
                Latitude = 12,
            };

            var newVm = DTOMapper<HolidayViewModelGet, DTOHoliday>.From(dtoH);
            var newDto = DTOMapper<DTOHoliday, HolidayViewModelGet>.From(vmH);

            Assert.That(newVm.Id, Is.EqualTo(dtoH.Id));
            Assert.That(newVm.Name, Is.EqualTo(null));
            Assert.That(newVm.StartDate, Is.EqualTo(dtoH.StartDate));
            Assert.That(newVm.EndDate, Is.EqualTo(dtoH.EndDate));
            Assert.That(newVm.Longitude, Is.EqualTo(0));
            Assert.That(newVm.Latitude, Is.EqualTo(0));

            Assert.That(newDto.Id, Is.EqualTo(vmH.Id));
            Assert.That(newDto.Name, Is.EqualTo(vmH.Name));
            Assert.That(newDto.StartDate, Is.EqualTo(vmH.StartDate));
            Assert.That(newDto.EndDate, Is.EqualTo(vmH.EndDate));
            Assert.That(newDto.Longitude, Is.EqualTo(vmH.Longitude));
            Assert.That(newDto.Latitude, Is.EqualTo(vmH.Latitude));

        }*/
    }
}
