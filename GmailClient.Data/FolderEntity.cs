using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient.Data
{
    [Table(Name = "Folders")]
    class FolderEntity
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
