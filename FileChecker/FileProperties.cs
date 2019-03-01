using System;
using System.Linq;
using System.Collections.Generic;

namespace FileProperties
{
    /// <summary>
    /// Returns the properties of a given file.
    /// </summary>
    public class FileProperties
    {
        /// <summary>
        /// Byte stream of the file.
        /// </summary>
        public byte[] File { get; }
        /// <summary>
        /// Signature of the file.
        /// </summary>
        public Signature Signature { get; }
        /// <summary>
        /// File size in Bytes.
        /// </summary>
        public ulong Size { get; }

        private readonly Dictionary<Signature, List<byte?[]>> _signatureDictionary = new Dictionary<Signature, List<byte?[]>>()
        {
            { Signature.ICO, new List<byte?[]>
                {
                    new byte?[] { 0x00, 0x00, 0x01, 0x00 }
                }
            },
            { Signature.TGP, new List<byte?[]>
                {
                    new byte?[] { 0x66, 0x74, 0x79, 0x70, 0x33, 0x67 }
                }
            },
            { Signature.TARZ, new List<byte?[]>
                {
                    new byte?[] { 0x1F, 0x9D },
                    new byte?[] { 0x1F, 0xA0 }
                }
            },
            { Signature.GIF, new List<byte?[]>
                {
                    new byte?[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 },
                    new byte?[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }
                }
            },
            { Signature.TIFF, new List<byte?[]>
                {
                    new byte?[] { 0x49, 0x49, 0x2A, 0x00 },
                    new byte?[] { 0x4D, 0x4D, 0x00, 0x2A }
                }
            },
            { Signature.JPG, new List<byte?[]>
                {
                    new byte?[] { 0x4D, 0x4D, 0x00, 0x2A }
                }
            },
            { Signature.JFIF, new List<byte?[]>
                {
                    new byte?[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 }
                }
            },
            { Signature.JPEG, new List<byte?[]>
                {
                    new byte?[] { 0xFF, 0xD8, 0xFF, 0xEE }
                }
            },
            { Signature.JExif, new List<byte?[]>
                {
                    new byte?[] { 0xFF, 0xD8, 0xFF, 0xE1, null, null, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00 }
                }
            },
            { Signature.EXE, new List<byte?[]>
                {
                    new byte?[] { 0x4D, 0x5A }
                }
            },
            { Signature.ZIP, new List<byte?[]>
                {
                    new byte?[] { 0x50, 0x4B, 0x03, 0x04 },
                    new byte?[] { 0x50, 0x4B, 0x05, 0x06 },
                    new byte?[] { 0x50, 0x4B, 0x07, 0x08 }
                }
            },
            { Signature.RAR, new List<byte?[]>
                {
                    new byte?[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 },
                    new byte?[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00 }
                }
            },
            { Signature.PNG, new List<byte?[]>
                {
                    new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
                }
            },
            { Signature.PDF, new List<byte?[]>
                {
                    new byte?[] { 0x25, 0x50, 0x44, 0x46, 0x2D }
                }
            },
            { Signature.OGG, new List<byte?[]>
                {
                    new byte?[] { 0x4F, 0x67, 0x67, 0x53 }
                }
            },
            { Signature.PSD, new List<byte?[]>
                {
                    new byte?[] { 0x38, 0x42, 0x50, 0x53 }
                }
            },
            { Signature.WAV, new List<byte?[]>
                {
                    new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null, 0x57, 0x41, 0x56, 0x45 }
                }
            },
            { Signature.AVI, new List<byte?[]>
                {
                    new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null, 0x41, 0x56, 0x49, 0x20 }
                }
            },
            { Signature.MP3, new List<byte?[]>
                {
                    new byte?[] { 0xFF, 0xFB }
                }
            },
            { Signature.MP3ID, new List<byte?[]>
                {
                    new byte?[] { 0x49, 0x44, 0x33 }
                }
            },
            { Signature.BMP, new List<byte?[]>
                {
                    new byte?[] { 0x42, 0x4D }
                }
            },
            { Signature.ISO, new List<byte?[]>
                {
                    new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }
                }
            },
            { Signature.FLAC, new List<byte?[]>
                {
                    new byte?[] { 0x66, 0x4C, 0x61, 0x43 }
                }
            },
            { Signature.MIDI, new List<byte?[]>
                {
                    new byte?[] { 0x4D, 0x54, 0x68, 0x64 }
                }
            },
            { Signature.DOC, new List<byte?[]>
                {
                    new byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }
                }
            },
            { Signature.TAR, new List<byte?[]>
                {
                    new byte?[] { 0x75, 0x73, 0x74, 0x61, 0x72, 0x00, 0x30, 0x30 },
                    new byte?[] { 0x75, 0x73, 0x74, 0x61, 0x72, 0x20, 0x20, 0x00 }
                }
            },
            { Signature.MLV, new List<byte?[]>
                {
                    new byte?[] { 0x4D, 0x4C, 0x56, 0x49 }
                }
            },
            { Signature.SEVENZ, new List<byte?[]>
                {
                    new byte?[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }
                }
            },
            { Signature.GZ, new List<byte?[]>
                {
                    new byte?[] { 0x1F, 0x8B }
                }
            },
            { Signature.XZ, new List<byte?[]>
                {
                    new byte?[] { 0xFD, 0x37, 0x7A, 0x58, 0x5A, 0x00, 0x00 }
                }
            },
            { Signature.FLIF, new List<byte?[]>
                {
                    new byte?[] { 0x46, 0x4C, 0x49, 0x46 }
                }
            },
            { Signature.MKV, new List<byte?[]>
                {
                    new byte?[] { 0x1A, 0x45, 0xDF, 0xA3 }
                }
            },
            { Signature.XML, new List<byte?[]>
                {
                    new byte?[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20 }
                }
            },
            { Signature.SWF, new List<byte?[]>
                {
                    new byte?[] { 0x43, 0x57, 0x53 },
                    new byte?[] { 0x46, 0x57, 0x53 }
                }
            },
            { Signature.RTF, new List<byte?[]>
                {
                    new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }
                }
            },
            { Signature.MPEG, new List<byte?[]>
                {
                    new byte?[] { 0x00, 0x00, 0x01, 0xBA },
                    new byte?[] { 0x47 },
                    new byte?[] { 0x00, 0x00, 0x01, 0xB3 }
                }
            }
        };

        private static readonly Signature[] _image =
        {
            Signature.ICO,
            Signature.BMP,
            Signature.GIF,
            Signature.JExif,
            Signature.JPG,
            Signature.JPEG,
            Signature.JFIF,
            Signature.PNG
        };
        private static readonly Signature[] _video =
        {
            Signature.TGP,
            Signature.WAV,
            Signature.AVI,
            Signature.MLV,
            Signature.MKV,
            Signature.MPEG
        };
        private static readonly Signature[] _audio =
        {
            Signature.MP3,
            Signature.MP3ID,
            Signature.FLAC,
            Signature.OGG,
            Signature.MIDI,
            Signature.WAV
        };

        /// <summary>
        /// Returns true if the file is an image.
        /// </summary>
        public bool IsImage()
        {
            foreach (Signature s in _image)
            {
                List<byte?[]> sBytes = _signatureDictionary[s];
                foreach (byte?[] signature in sBytes)
                {
                    bool found = true;
                    foreach (var b in signature.Select((value, i) => new { i, value }))
                    {
                        if (b.value != null)
                        {
                            if (b.value != File[b.i])
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if the file is a video.
        /// </summary>
        public bool IsVideo()
        {
            foreach (Signature s in _video)
            {
                List<byte?[]> sBytes = _signatureDictionary[s];
                foreach (byte?[] signature in sBytes)
                {
                    bool found = true;
                    foreach (var b in signature.Select((value, i) => new { i, value }))
                    {
                        if (b.value != null)
                        {
                            if (b.value != File[b.i])
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if the file is an audio.
        /// </summary>
        public bool IsAudio()
        {
            foreach (Signature s in _audio)
            {
                List<byte?[]> sBytes = _signatureDictionary[s];
                foreach (byte?[] signature in sBytes)
                {
                    bool found = true;
                    foreach (var b in signature.Select((value, i) => new { i, value }))
                    {
                        if (b.value != null)
                        {
                            if (b.value != File[b.i])
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if the file signature is contained in the provided list.
        /// </summary>
        /// <param name="signatures">The list of signatures to be checked.</param>
        public bool CheckExtension(Signature[] signatures)
        {
            foreach (Signature signature in signatures)
            {
                List<byte?[]> sBytes = _signatureDictionary[signature];
                foreach (byte?[] s in sBytes)
                {
                    bool found = true;
                    foreach (var b in s.Select((value, i) => new { i, value }))
                    {
                        if (b.value != null)
                        {
                            if (b.value != File[b.i])
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if the file is under or equals the given size.
        /// </summary>
        /// <param name="size">The size in Bytes</param>
        public bool IsUnderSize(ulong size)
        {
            return (Size <= size);
        }
        /// <summary>
        /// Converts a value in Kilobytes to Bytes.
        /// </summary>
        /// <param name="value">Value in Kilobites.</param>
        /// <returns>Value in Bytes stored in a unsigned long integer.</returns>
        public static ulong FromKilobytes(int value)
        {
            return (ulong)value * 1024;
        }
        /// <summary>
        /// Converts a value in Megabytes to Bytes.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value in Bytes stored in a unsigned long integer.</returns>
        public static ulong FromMegabytes(int value)
        {
            return (ulong)value * 1048576;
        }

        private Signature GetSignature()
        {
            foreach (var item in _signatureDictionary)
            {
                foreach (byte?[] sBytes in item.Value)
                {
                    bool found = true;
                    foreach (var b in sBytes.Select((value, i) => new { i, value }))
                    {
                        if (b.value != null)
                        {
                            if (b.value != File[b.i])
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        return item.Key;
                    }
                }
            }
            return Signature.Undefined;
        }

        public FileProperties(byte[] file)
        {
            File = file;
            Signature = GetSignature();
            Size = (ulong)file.Length;
        }
    }
}
