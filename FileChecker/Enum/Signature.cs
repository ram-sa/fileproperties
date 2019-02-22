using System;
using System.Collections.Generic;
using System.Text;

namespace FileProperties
{
    public enum Signature : byte
    {
        /// <summary>
        /// *.ico file signature.
        /// </summary>
        ICO,

        /// <summary>
        /// *.3gp and .3g2 file signature.
        /// </summary>
        TGP,

        /// <summary>
        /// *.z and *.tar.z using Lempel-Ziv-Welch or LZH compression algorithm file signature.
        /// </summary>
        TARZ,

        /// <summary>
        /// *.gif file signature.
        /// </summary>
        GIF,

        /// <summary>
        /// *.tif and *.tiff files signature.
        /// </summary>
        TIFF,

        /// <summary>
        /// *.jpg raw file signature.
        /// </summary>
        JPG,

        /// <summary>
        /// *.jpg or *.jpeg JFIF file format signature.
        /// </summary>
        JFIF,

        /// <summary>
        /// *.jpeg raw file signature.
        /// </summary>
        JPEG,

        /// <summary>
        /// *.jpg or *.jpeg Exif file format signature.
        /// </summary>
        JExif,

        /// <summary>
        /// *.exe file signature.
        /// </summary>
        EXE,

        /// <summary>
        /// *.zip, *.jar, *.odt, *.ods, *.odp, *.docx, *.xlsx, *.pptx, *.vsdx, *.apk, *.aar file signature.
        /// </summary>
        ZIP,

        /// <summary>
        /// *.rar file signature.
        /// </summary>
        RAR,

        /// <summary>
        /// *.png file signature.
        /// </summary>
        PNG,

        /// <summary>
        /// *.pdf file signature.
        /// </summary>
        PDF,

        /// <summary>
        /// *.ogg, *oga and *ogv files signature.
        /// </summary>
        OGG,

        /// <summary>
        /// *.psd file signature.
        /// </summary>
        PSD,

        /// <summary>
        /// *.wav file signature.
        /// </summary>
        WAV,

        /// <summary>
        /// *.avi file signature.
        /// </summary>
        AVI,

        /// <summary>
        /// *.mp3 with or without a ID3v1 container file signature.
        /// </summary>
        MP3,

        /// <summary>
        /// *.mp3 with a ID3v2 container file signature.
        /// </summary>
        MP3ID,

        /// <summary>
        /// *.bmp and *.dib files signature.
        /// </summary>
        BMP,

        /// <summary>
        /// *.iso file signature.
        /// </summary>
        ISO,

        /// <summary>
        /// *.flac file signature.
        /// </summary>
        FLAC,

        /// <summary>
        /// *.mid and *.midi files signature.
        /// </summary>
        MIDI,

        /// <summary>
        /// *.doc, *.xls, *.ppt and *.msg files signature.
        /// </summary>
        DOC,

        /// <summary>
        /// *.tar file signature.
        /// </summary>
        TAR,

        /// <summary>
        /// *.mlv file signature.
        /// </summary>
        MLV,

        /// <summary>
        /// *.7z file signature.
        /// </summary>
        SEVENZ,

        /// <summary>
        /// *.gz and *.tar.gz files signature.
        /// </summary>
        GZ,

        /// <summary>
        /// *.xz and *.tar.xz files signature.
        /// </summary>
        XZ,

        /// <summary>
        /// *.flif file signature.
        /// </summary>
        FLIF,

        /// <summary>
        /// *.mkv, *.mka, *.mks, *.mk3d and *.webm files signature.
        /// </summary>
        MKV,

        /// <summary>
        /// *.xml file signature.
        /// </summary>
        XML,

        /// <summary>
        /// *.swf file signature.
        /// </summary>
        SWF,

        /// <summary>
        /// *.rtf file signature.
        /// </summary>
        RTF,

        /// <summary>
        /// *.mpg and *.mpeg files signature.
        /// </summary>
        MPEG,

        /// <summary>
        /// File signature could not be recognized.
        /// </summary>
        Undefined
    }
}
