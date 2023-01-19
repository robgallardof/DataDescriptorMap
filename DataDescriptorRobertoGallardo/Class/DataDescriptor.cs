namespace DataDescriptorRobertoGallardo.Class
{
    internal class DataDescriptor
    {
        /// <summary>
        /// Name of the Map or Field.
        /// </summary>
        public string Name;

        /// <summary>
        /// Name of the field or Type that this DataDescriptor
        /// </summary>
        public string Alias;

        /// <summary>
        /// Describes this field or Type defined in this data
        /// </summary>
        public string MapDescription;

        /// <summary>
        /// Flag that says if the data type describes in this Dal
        /// </summary>
        public bool Primitive;

        /// <summary>
        /// Flag indicates if Field described in this DataDescripto
        /// </summary>
        public bool Multiple;

        /// <summary>
        /// Flag indicates the Type of object.
        /// </summary>
        public string Type;

        /// <summary>
        /// Fields (if needed) of the object type described in the
        /// </summary>
        public DataDescriptor[] Fields;
    }
}