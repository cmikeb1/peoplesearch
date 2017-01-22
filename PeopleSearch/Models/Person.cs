namespace PeopleSearch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFirst { get; set; }

        [Required]
        [StringLength(50)]
        public string NameLast { get; set; }

        [StringLength(20)]
        public string NameTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressStreet { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressCity { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressState { get; set; }

        [Required]
        [StringLength(10)]
        public string AddressPostcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(2018)]
        public string PictureLarge { get; set; }

        [Required]
        [StringLength(2018)]
        public string PictureMeium { get; set; }

        [Required]
        [StringLength(2018)]
        public string PictureThumbnail { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public DateTime CreatedDatetime { get; set; }
    }
}
