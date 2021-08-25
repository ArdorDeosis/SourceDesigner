using System;

namespace SourceDesigner
{
    public record CodeStyle
    {
        private int spacesPerIndentation = 4;

        public int SpacesPerIndentation
        {
            get => spacesPerIndentation;
            set
            {
                // TODO: custom exception; also: is validating in the setter good practice?
                if (value < 0)
                    throw new Exception("negative indentation is a bad idea");
                spacesPerIndentation = value;
            }
        }

        public string Indentation => new(' ', SpacesPerIndentation);
    }
}