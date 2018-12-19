/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DncZeus.Api.Entities
{
    public abstract class AuditEntity
    {
        [Column(Order = 100)]
        public DateTime CreatedOn { get; set; }
        [Column(Order = 101)]
        public int CreatedByUserId { get; set; }
        [Column(Order = 102)]
        public string CreatedByUserName { get; set; }
        [Column(Order = 103)]
        public DateTime? ModifiedOn { get; set; }
        [Column(Order = 104)]
        public int ModifiedByUserId { get; set; }
        [Column(Order = 105)]
        public string ModifiedByUserName { get; set; }
    }
}
