using System.ComponentModel;

namespace WebClient
{
    public enum MediaType
    {
        [Description("*/*")] ALL,

        [Description("application/atom+xml*")] APPLICATION_ATOM_XML,

        [Description("application/x-www-form-urlencoded")] APPLICATION_FORM_URLENCODED,

        [Description("application/json")] APPLICATION_JSON,

        [Description("application/octet-stream")] APPLICATION_OCTET_STREAM,

        [Description("application/xhtml+xml")] APPLICATION_XHTML_XML,

        [Description("application/xml")] APPLICATION_XML,

        [Description("image/gif")] IMAGE_GIF,

        [Description("image/jpeg")] IMAGE_JPEG,

        [Description("image/png")] IMAGE_PNG,

        [Description("multipart/form-data")] MULTIPART_FORM_DATA,

        [Description("text/html")] TEXT_HTML,

        [Description("text/plain")] TEXT_PLAIN,

        [Description("text/xml")] TEXT_XML
    }

    public static class MediaTypeHelper
    {
        //    public static MediaType parseMediaType(string mediaType) {
        //        MediaType type;
        //    try {
        //        type = MimeTypeUtils.parseMimeType(mediaType);
        //    }
        //    catch (InvalidMimeTypeException ex) {
        //        throw new InvalidMediaTypeException(ex);
        //    }
        //    try {
        //        return new MediaType(type.getType(), type.getSubtype(), type.getParameters());
        //    }
        //    catch (IllegalArgumentException ex) {
        //        throw new InvalidMediaTypeException(mediaType, ex.getMessage());
        //    }
        //}
        //    public static MimeType parseMimeType(String mimeType)
        //    {
        //        if (string.IsNullOrWhiteSpace(mimeType))
        //        {
        //            throw new ArgumentException("\'mimeType\' must not be empty", mimeType);
        //        }
        //        else
        //        {
        //            String[] parts = mimeType.Split(';');
        //            String fullType = parts[0].Trim();
        //            if ("*".Equals(fullType))
        //            {
        //                fullType = "*/*";
        //            }

        //            int subIndex = fullType.IndexOf((char) 47);
        //            if (subIndex == -1)
        //            {
        //                throw new ArgumentException("does not contain \'/\'", mimeType);
        //            }
        //            else if (subIndex == fullType.Length - 1)
        //            {
        //                throw new ArgumentException("does not contain subtype after \'/\'", mimeType);
        //            }
        //            else
        //            {
        //                String type = fullType.Substring(0, subIndex);
        //                String subtype = fullType.Substring(subIndex + 1, fullType.Length);
        //                if ("*".Equals(type) && !"*".Equals(subtype))
        //                {
        //                    throw new ArgumentException("wildcard type is legal only in \'*/*\' (all mime types)", mimeType);
        //                }
        //                else
        //                {
        //                    LinkedHashMap parameters = null;
        //                    if (parts.length > 1)
        //                    {
        //                        parameters = new LinkedHashMap(parts.length - 1);

        //                        for (int ex = 1; ex < parts.length; ++ex)
        //                        {
        //                            String parameter = parts[ex];
        //                            int eqIndex = parameter.indexOf(61);
        //                            if (eqIndex != -1)
        //                            {
        //                                String attribute = parameter.substring(0, eqIndex);
        //                                String value = parameter.substring(eqIndex + 1, parameter.length());
        //                                parameters.put(attribute, value);
        //                            }
        //                        }
        //                    }

        //                    try
        //                    {
        //                        return new MimeType(type, subtype, parameters);
        //                    }
        //                    catch (UnsupportedCharsetException var12)
        //                    {
        //                        throw new InvalidMimeTypeException(mimeType, "unsupported charset \'" + var12.getCharsetName() + "\'");
        //                    }
        //                    catch (IllegalArgumentException var13)
        //                    {
        //                        throw new InvalidMimeTypeException(mimeType, var13.getMessage());
        //                    }
        //                }
        //            }
        //        }
        //    }

        ///**
        // * Parse the given, comma-separated string into a list of {@code MediaType} objects.
        // * <p>This method can be used to parse an Accept or Content-Type header.
        // * @param mediaTypes the string to parse
        // * @return the list of media types
        // * @throws IllegalArgumentException if the string cannot be parsed
        // */
        //public static List<MediaType> parseMediaTypes(string mediaTypes) {
        //    if (!StringUtils.hasLength(mediaTypes)) {
        //        return Collections.emptyList();
        //    }
        //    String[] tokens = mediaTypes.split(",\\s*");
        //    List<MediaType> result = new ArrayList<MediaType>(tokens.length);
        //    for (String token : tokens) {
        //        result.add(parseMediaType(token));
        //    }
        //    return result;
        //}
    }
}