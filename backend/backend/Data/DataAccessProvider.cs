using backend.Models;
using backend.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DataDbContext db;
        GeneralOutputModel output = new GeneralOutputModel();


        public DataAccessProvider(DataDbContext _db)
        {
            db = _db;
        }

        public GeneralOutputModel loginUser(LoginModel pr)
        {
            try
            {

                var dt = db.ms_user.Where(p => p.user_name == pr.user_name && p.password == pr.password).FirstOrDefault();

                if (dt != null)
                {
                    output.Status = "OK";
                    output.Result = dt;
                    output.Message = "Success Login";
                }

                else
                {
                    output.Status = "NG";
                    output.Message = "Failed Login";
                }


            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = "Failed Login";
            }
            return output;
        }

        public async Task<GeneralOutputModel> InsertDataAsync(Bpkbstore pr)
        {
            var output = new GeneralOutputModel();

            // Cek jika ada parameter yang null
            if (pr.agreement_number == null ||
                pr.branch_id == null ||
                pr.bpkb_no == null ||
                pr.bpkb_date_in == null ||
                pr.bpkb_date == null ||
                pr.faktur_no == null ||
                pr.faktur_date == null ||
                pr.police_no == null ||
                pr.location_id == null ||
                pr.created_by == null)
            {
                output.Status = "NG";
                output.Message = "One or more parameters are null. Insert operation aborted.";
                return output;
            }

            // SQL query to insert data
                    string sql = @"
            INSERT INTO tr_bpkb (
                agreement_number, branch_id, bpkb_no, bpkb_date_in, bpkb_date,
                faktur_no, faktur_date, police_no, location_id, created_by, 
                last_updated_by, created_on, last_updated_on
            ) VALUES (
                @agreement_number, @branch_id, @bpkb_no, @bpkb_date_in, @bpkb_date,
                @faktur_no, @faktur_date, @police_no, @location_id, @created_by,
                @last_updated_by, @created_on, @last_updated_on
            )";

            try
            {
                await db.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@agreement_number", pr.agreement_number),
                    new SqlParameter("@branch_id", pr.branch_id),
                    new SqlParameter("@bpkb_no", pr.bpkb_no),
                    new SqlParameter("@bpkb_date_in", pr.bpkb_date_in),
                    new SqlParameter("@bpkb_date", pr.bpkb_date),
                    new SqlParameter("@faktur_no", pr.faktur_no),
                    new SqlParameter("@faktur_date", pr.faktur_date),
                    new SqlParameter("@police_no", pr.police_no),
                    new SqlParameter("@location_id", pr.location_id),
                    new SqlParameter("@created_by", pr.created_by),
                    new SqlParameter("@last_updated_by", pr.created_by), // Assuming last_updated_by is same as created_by
                    new SqlParameter("@created_on", DateTime.Now),
                    new SqlParameter("@last_updated_on", DateTime.Now));

                output.Status = "OK";
                output.Message = "Data inserted successfully";
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();
            }

            return output;
        }


        public async Task<GeneralOutputModel> UpdateDataAsync(Bpkbstore pr)
        {
            var output = new GeneralOutputModel();

            // Cek jika ada parameter yang null
            if (pr.idupdate == null ||
                pr.agreement_number == null ||
                pr.branch_id == null ||
                pr.bpkb_no == null ||
                pr.bpkb_date_in == null ||
                pr.bpkb_date == null ||
                pr.faktur_no == null ||
                pr.faktur_date == null ||
                pr.police_no == null ||
                pr.location_id == null ||
                pr.created_by == null)
            {
                output.Status = "NG";
                output.Message = "One or more parameters are null. Update operation aborted.";
                return output;
            }

            // SQL query to update data
            string sql = @"
                UPDATE tr_bpkb
                SET 
                    agreement_number = @agreement_number,
                    branch_id = @branch_id,
                    bpkb_no = @bpkb_no,
                    bpkb_date_in = @bpkb_date_in,
                    bpkb_date = @bpkb_date,
                    faktur_no = @faktur_no,
                    faktur_date = @faktur_date,
                    police_no = @police_no,
                    location_id = @location_id,
                    last_updated_by = @last_updated_by,
                    last_updated_on = @last_updated_on
                    WHERE agreement_number = @id";

            try
            {
                await db.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@agreement_number", pr.agreement_number),
                    new SqlParameter("@branch_id", pr.branch_id),
                    new SqlParameter("@bpkb_no", pr.bpkb_no),
                    new SqlParameter("@bpkb_date_in", pr.bpkb_date_in),
                    new SqlParameter("@bpkb_date", pr.bpkb_date),
                    new SqlParameter("@faktur_no", pr.faktur_no),
                    new SqlParameter("@faktur_date", pr.faktur_date),
                    new SqlParameter("@police_no", pr.police_no),
                    new SqlParameter("@location_id", pr.location_id),
                    new SqlParameter("@last_updated_by", pr.created_by), // Assuming last_updated_by is same as created_by
                    new SqlParameter("@last_updated_on", DateTime.Now),
                    new SqlParameter("@id", pr.idupdate)); // Add ID parameter to the SQL query

                output.Status = "OK";
                output.Message = "Data updated successfully";
            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();
            }

            return output;
        }


        public GeneralOutputModel Getdatalocations()
        {
            GeneralOutputModel output = new GeneralOutputModel();
            try
            {
                var dataLocation = (from c in db.ms_storage_location

                                    select new ms_storage_location
                                   {
                                       location_id = c.location_id,
                                       location_name = c.location_name,
                                   }).ToList();

                output.Status = "OK";
                output.Result = dataLocation;
                output.Message = "Sukses mengambil data";

                //return output;

            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                //return output;
            }
            return output;

        }

        public GeneralOutputModel GetdataBpkb()
        {
            GeneralOutputModel output = new GeneralOutputModel();
            try
            {
                var dataContent = (from c in db.tr_bpkb
                                   join tp in db.ms_storage_location
                                   on c.location_id equals tp.location_id
                                   join tk in db.ms_user
                                   on c.created_by equals tk.user_name
                                   select new ouputBpkb
                                   {
                                       agreement_number = c.agreement_number,
                                       branch_id = c.branch_id,
                                       bpkb_no = c.bpkb_no,
                                       bpkb_date_in = c.bpkb_date_in.HasValue ? c.bpkb_date_in.Value.ToString("yyyy-MM-dd") : null,
                                       bpkb_date = c.bpkb_date.HasValue ? c.bpkb_date.Value.ToString("yyyy-MM-dd") : null,
                                       faktur_no = c.faktur_no,
                                       faktur_date = c.faktur_date.HasValue ? c.faktur_date.Value.ToString("yyyy-MM-dd") : null,
                                       police_no = c.police_no,
                                       location_name = tp.location_name,
                                       created_by = c.created_by,
                                       created_on = c.created_on
                                   }).ToList();

                output.Status = "OK";
                output.Result = dataContent;
                output.Message = "Sukses mengambil data";

                return output;

            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return output;
            }
        }

        public GeneralOutputModel GetdatabyIdBpkb(byId pr)
        {
            GeneralOutputModel output = new GeneralOutputModel();
            try
            {
                var dataContent = (from c in db.tr_bpkb.Where(p => p.agreement_number == pr.id)
                                   join tp in db.ms_storage_location
                                   on c.location_id equals tp.location_id
                                   join tk in db.ms_user
                                   on c.created_by equals tk.user_name
                                   select new ouputBpkb
                                   {
                                       agreement_number = c.agreement_number,
                                       branch_id = c.branch_id,
                                       bpkb_no = c.bpkb_no,
                                       bpkb_date_in = c.bpkb_date_in.HasValue ? c.bpkb_date_in.Value.ToString("yyyy-MM-dd") : null,
                                       bpkb_date = c.bpkb_date.HasValue ? c.bpkb_date.Value.ToString("yyyy-MM-dd") : null,
                                       faktur_no = c.faktur_no,
                                       faktur_date = c.faktur_date.HasValue ? c.faktur_date.Value.ToString("yyyy-MM-dd") : null,
                                       police_no = c.police_no,
                                       location_name = tp.location_name,
                                       location_id = tp.location_id,
                                       created_by = c.created_by,
                                       created_on = c.created_on
                                   }).ToList();

                output.Status = "OK";
                output.Result = dataContent;
                output.Message = "Sukses mengambil data";

                return output;

            }
            catch (Exception ex)
            {
                output.Status = "NG";
                output.Message = ex.ToString();

                return output;
            }
        }


    }
}
