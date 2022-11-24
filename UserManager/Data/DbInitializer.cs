using System.Net;
using UserManager.Data.Enum;
using UserManager.Data.Model;

namespace UserManager.Data
{
    public static class DbInitializer
    {
        public static void Initializer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.AccessRoles.Any())
            {
                context.AccessRoles.AddRange(new List<AccessRole>()
                    {
                        new AccessRole()
                        {
                            Role = "Owner"
                        },
                        new AccessRole()
                        {
                            Role = "Admin"
                        },
                        new AccessRole()
                        {
                            Role = "Editor"
                        },
                        new AccessRole()
                        {
                            Role = "Viewer"
                        }
                    });
                context.SaveChanges();
            }
            if (!context.AccessRules.Any())
            {
                context.AccessRules.AddRange(new List<AccessRule>()
                    {
                        // Owner
                        // Folder Rule
                        new AccessRule()
                        {
                            Path = "*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = false,
                            AccessRoleId = 1
                        },
                        // File Rule
                        new AccessRule()
                        {
                            Path = "/",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = true,
                            AccessRoleId = 1
                        },

                        // Admin
                        // Folder Rule
                        new AccessRule()
                        {
                            Path = "*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = false,
                            AccessRoleId = 2
                        },

                        // File Rule
                        new AccessRule()
                        {
                            Path = "/",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = true,
                            AccessRoleId = 1
                        },

                        // Editor
                        // Folder rule
                        new AccessRule()
                        {
                            Path = "*",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Deny,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 3
                        },
                        new AccessRule()
                        {
                            Path = "/",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 3
                        },
                        new AccessRule()
                        {
                            Path = "/Document",
                            Copy = Permission.Deny,
                            Download = Permission.Allow,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = false,
                            AccessRoleId = 3
                        },
                        new AccessRule()
                        {
                            Path = "/Document/*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = false,
                            AccessRoleId = 3
                        },

                        // File Rule
                        new AccessRule()
                        {
                            Path = "*.*",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Deny,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = true,
                            AccessRoleId = 3
                        },
                        new AccessRule()
                        {
                            Path = "/Document/*.*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Allow,
                            Read = Permission.Allow,
                            WriteContents = Permission.Allow,
                            Upload = Permission.Allow,
                            IsFile = true,
                            AccessRoleId = 3
                        },

                        // Viewer
                        // Folder rule
                        new AccessRule()
                        {
                            Path = "*",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Deny,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 4
                        },
                        new AccessRule()
                        {
                            Path = "/",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 4
                        },
                        new AccessRule()
                        {
                            Path = "/Document",
                            Copy = Permission.Deny,
                            Download = Permission.Deny,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 4
                        },
                        new AccessRule()
                        {
                            Path = "/Document/*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = false,
                            AccessRoleId = 4
                        },

                        // File Rule
                        new AccessRule()
                        {
                            Path = "/Document/*.*",
                            Copy = Permission.Allow,
                            Download = Permission.Allow,
                            Write = Permission.Deny,
                            Read = Permission.Allow,
                            WriteContents = Permission.Deny,
                            Upload = Permission.Deny,
                            IsFile = true,
                            AccessRoleId = 4
                        },
                    });
                context.SaveChanges();
            }
        }
    }
}
