using HIVMedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.Seedings;

public class DataSeeding
{
    private static DataSeeding _instance;

    public DataSeeding()
    {
        
    }

    public static DataSeeding Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataSeeding();
            } 
            return _instance;
        }
    }
    public async Task MigrateDatabaseAsync()
    {
        try
        {
            using var context = new AppDbContext();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task RoleSeedingAsync()
    {
        try
        {
            using var context = new AppDbContext();
            var roles = await context.Roles.ToListAsync();
            if (roles.Any()) return;
            var rolesCreated = new List<Role>()
            {
                new Role()
                {
                    RoleName = "Staff",
                    IsDeleted = false,
                },
                new Role()
                {
                    RoleName = "Admin",
                    IsDeleted = false
                },
                new Role()
                {
                    RoleName = "Customer",
                    IsDeleted = false
                },
                new Role()
                {
                    RoleName = "Doctor",
                    IsDeleted = false
                }
            };
            await context.Roles.AddRangeAsync(rolesCreated);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task UserSeedingAsync()
    {
        try
        {
            using var context = new AppDbContext();
            if (await context.Users.AnyAsync()) return;
            var userCreated = new List<User>()
            {
                new User()
                {
                    FullName = "Hồ Dương Trung Nguyên",
                    RoleId = 1,
                    Email = "nguyenhdtse172921@fpt.edu.vn",
                    Password = "12345678",
                    PhoneNumber = "0123",
                    IsDeleted = false,
                },
                new User
                {
                    FullName = "Nguyễn Văn An",
                    RoleId = 3,
                    Email = "an.nguyen@example.com",
                    Password = "12345678",
                    PhoneNumber = "0901234567",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Trần Thị Bích",
                    RoleId = 3,
                    Email = "bich.tran@example.com",
                    Password = "12345678",
                    PhoneNumber = "0912345678",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Lê Hoàng Phúc",
                    RoleId = 3,
                    Email = "phuc.le@example.com",
                    Password = "12345678",
                    PhoneNumber = "0923456789",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Phạm Minh Khoa",
                    RoleId = 3,
                    Email = "khoa.pham@example.com",
                    Password = "12345678",
                    PhoneNumber = "0934567890",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Đặng Thị Thảo",
                    RoleId = 3,
                    Email = "thao.dang@example.com",
                    Password = "12345678",
                    PhoneNumber = "0945678901",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Nguyễn Thị Lan",
                    RoleId = 4,
                    Email = "lan.nguyen@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002001",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Trần Văn Hùng",
                    RoleId = 4,
                    Email = "hung.tran@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002002",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Lê Thanh Tú",
                    RoleId = 4,
                    Email = "tu.le@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002003",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Phạm Quang Dũng",
                    RoleId = 4,
                    Email = "dung.pham@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002004",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Võ Thị Kim Anh",
                    RoleId = 4,
                    Email = "kimanh.vo@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002005",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Đinh Công Minh",
                    RoleId = 4,
                    Email = "minh.dinh@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002006",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Hoàng Gia Bảo",
                    RoleId = 4,
                    Email = "bao.hoang@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002007",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Dr. Nguyễn Thị Mai",
                    RoleId = 4,
                    Email = "mai.nguyen@hospital.com",
                    Password = "12345678",
                    PhoneNumber = "0981002008",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Staff Nguyễn Văn Khánh",
                    RoleId = 1,
                    Email = "khanh.nguyen@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001001",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Staff Trần Thị Hồng",
                    RoleId = 1,
                    Email = "hong.tran@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001002",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Staff Lê Minh Nhật",
                    RoleId = 1,
                    Email = "nhat.le@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001003",
                    IsDeleted = false
                },
                new User
                {
                    FullName = "Staff Phạm Hữu Toàn",
                    RoleId = 1,
                    Email = "toan.pham@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001004",
                    IsDeleted = false
                },
                new()
                {
                    FullName = "Staff Đỗ Thị Lệ",
                    RoleId = 1,
                    Email = "le.do@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001005",
                    IsDeleted = false
                },
                new()
                {
                    FullName = "Staff Bùi Quang Huy",
                    RoleId = 1,
                    Email = "huy.bui@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001006",
                    IsDeleted = false
                },
                new()
                {
                    FullName = "Staff Vũ Hồng Ngọc",
                    RoleId = 1,
                    Email = "ngoc.vu@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001007",
                    IsDeleted = false
                },
                new User()
                {
                    FullName = "Staff Mai Văn Dũng",
                    RoleId = 1,
                    Email = "dung.mai@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001008",
                    IsDeleted = false
                },
                new User()
                {
                    FullName = "Admin",
                    RoleId = 2,
                    Email = "admin@admin.com",
                    Password = "12345678",
                    PhoneNumber = "0977001009",
                    IsDeleted = false
                }
            };
            await context.AddRangeAsync(userCreated);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task DegreeTypeSeedingAsync()
    {
        try
        {
            using var context = new AppDbContext();
            if (await context.DegreeTypes.AnyAsync()) return;
            var degreeTypes = new List<DegreeType>()
            {
                new DegreeType()
                {
                    DegreeTypeName = "Doctor's Degree",
                    IsDeleted = false,
                }
            };
            await context.DegreeTypes.AddRangeAsync(degreeTypes);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task DegreeSeedingAsync()
    {
        try
        {
            using var context = new AppDbContext();
            if (await context.Degrees.AnyAsync()) return;
            var doctors = await context.Users.Where(item => item.RoleId == 3).ToListAsync();
            var degrees = new List<Degree>();
            foreach (var doctor in doctors)
            {
                degrees.Add(new()
                {
                    DegreeName = "Doctor's Degrees",
                    DegreeTypeId = 1,
                    IsDeleted = false,
                    UserId = doctor.Id,
                });
            }
            await context.Degrees.AddRangeAsync(degrees);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task ARVProtocolSeedingAsync()
    {
        try
        {
            Console.WriteLine("Hehe");
            using var context = new AppDbContext();
            if (await context.ARVProtocols.AnyAsync()) return;
            var protocols = new List<ARVProtocol>()
            {
                new ARVProtocol
                {
                    Name = "TDF + 3TC + DTG",
                    TargetGroup = "Người lớn",
                    Line = "Bậc 1",
                    Description = "Phác đồ ưu tiên. Hiệu quả cao, ít tác dụng phụ. Không dùng nếu suy thận nặng."
                },
                new ARVProtocol
                {
                    Name = "TDF + 3TC + EFV",
                    TargetGroup = "Người lớn",
                    Line = "Bậc 1",
                    Description = "Phác đồ thay thế khi không có DTG. Dùng liều 1 viên/ngày."
                },
                new ARVProtocol
                {
                    Name = "ABC + 3TC + DTG",
                    TargetGroup = "Người lớn",
                    Line = "Bậc 1",
                    Description = "Dùng khi không dung nạp TDF. Chống chỉ định nếu dị ứng với Abacavir."
                },
                new ARVProtocol
                {
                    Name = "TDF + 3TC + DTG",
                    TargetGroup = "Phụ nữ mang thai",
                    Line = "Bậc 1",
                    Description = "An toàn từ tuần thứ 6 của thai kỳ. Theo dõi định kỳ chức năng gan và tải lượng virus."
                },
                new ARVProtocol
                {
                    Name = "TDF + 3TC + EFV",
                    TargetGroup = "Phụ nữ mang thai",
                    Line = "Bậc 1",
                    Description = "Có thể sử dụng trong thai kỳ nếu không có DTG."
                },
                new ARVProtocol
                {
                    Name = "ABC + 3TC + LPV/r",
                    TargetGroup = "Trẻ em < 3 tuổi",
                    Line = "Bậc 1",
                    Description = "Liều theo cân nặng. Lưu ý theo dõi tác dụng phụ đường tiêu hóa."
                },
                new ARVProtocol
                {
                    Name = "ABC + 3TC + DTG",
                    TargetGroup = "Trẻ em ≥ 10kg",
                    Line = "Bậc 1",
                    Description = "Hiệu quả cao, ít tương tác thuốc. Dễ sử dụng cho trẻ."
                },
                new ARVProtocol
                {
                    Name = "TDF + 3TC + ATV/r",
                    TargetGroup = "Người lớn",
                    Line = "Bậc 2",
                    Description = "Phác đồ thay thế khi thất bại bậc 1. Theo dõi men gan và lipid máu."
                },
                new ARVProtocol
                {
                    Name = "AZT + 3TC + LPV/r",
                    TargetGroup = "Người lớn",
                    Line = "Bậc 2",
                    Description = "Áp dụng khi phác đồ có EFV thất bại. Có thể gây thiếu máu, cần theo dõi huyết học."
                },
                new ARVProtocol
                {
                    Name = "DTG + DRV/r + 3TC",
                    TargetGroup = "Người kháng thuốc nhiều",
                    Line = "Bậc 2/3",
                    Description = "Phác đồ mạnh cho bệnh nhân đã thất bại nhiều lần. Chi phí cao, tác dụng phụ nhiều hơn."
                }
            };
            await context.ARVProtocols.AddRangeAsync(protocols);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }
}