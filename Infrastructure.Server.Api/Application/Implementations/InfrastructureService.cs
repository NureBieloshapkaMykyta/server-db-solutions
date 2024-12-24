using Application.Abstractions;
using DataAccess;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations;

public class InfrastructureService(InfrastructureContext context) : IInfrastructureService
{

    public async Task<bool> AddAddress(string country, string city, string street)
    {
        try
        {
            var parameters = new[]
            {
                new SqlParameter("@street", street),
                new SqlParameter("@city", city),
                new SqlParameter("@country", country)
            };

            await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[insert_address] @street, @city, @country", parameters);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<string> GetInsertFlatException(short size, bool hasBalcony, bool hasParkingSpace, bool isRented, long? entranceId = null)
    {
        try
        {
            var parameters = new[]
            {
                new SqlParameter("@size", size),
                new SqlParameter("@has_balcony", hasBalcony),
                new SqlParameter("@has_parking_space", hasParkingSpace),
                new SqlParameter("@is_rented", isRented),
                new SqlParameter("@entrance_id", (object?)entranceId ?? DBNull.Value)
            };

            await context.Database.ExecuteSqlRawAsync("EXEC [dbo].[insert_flat] @size, @has_balcony, @has_parking_space, @is_rented, @entrance_id", parameters);

            return "Flat inserted successfully.";
        }
        catch (SqlException ex)
        {
            if (ex.Number == 50000)
            {
                return $"Error: {ex.Message}";
            }

            throw;
        }
    }

    public async Task<short> GetLessThanAvgFlatSize() 
    {
        var resultParameter = new SqlParameter
        {
            ParameterName = "@Result",
            SqlDbType = System.Data.SqlDbType.SmallInt,
            Direction = System.Data.ParameterDirection.Output
        };

        await context.Database.ExecuteSqlRawAsync("SET @Result = [dbo].[less_than_avg]()", resultParameter);

        return (short)resultParameter.Value;
    }
}
