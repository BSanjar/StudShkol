using System;
using System.Collections.Generic;

namespace Domain
{
    public class Promocode
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public DateTime dateCreate { get; set; }
        public string status { get; set; }//wait, in process, processed
        public DateTime dateStartUsing { get; set; }
        public DateTime dateFinishUsing { get; set; }
        public List<StudentTest> StudentTest { get; set; }
    }
}