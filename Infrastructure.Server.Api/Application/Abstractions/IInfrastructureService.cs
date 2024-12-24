using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IInfrastructureService
{
    Task<bool> AddAddress(string country,  string city,  string street);
    Task<short> GetLessThanAvgFlatSize();
    Task<string> GetInsertFlatException(short size, bool hasBalcony, bool hasParkingSpace, bool isRented, long? entranceId = null);
}
