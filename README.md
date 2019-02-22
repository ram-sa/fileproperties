# FileProperties
A lightweight C# library for file validation and metadata checking.


## Description

FileProperties is a small class library designed to help people manipulate and validate files by providing some basic information 
about them. This information includes:
- Size

The size of the file in bytes.
- Extension

The extension of the file, taken straight from the magic bytes. No reliance on MIME types!


## Features

- Lightweight

The file signatures are kept in a `Dictionary`, which allows for [very fast value retrieval](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2#remarks).
Besides, all loops are optimized to run only as much as necessary.

- Usability

This library includes a few methods for easy file validation, as well as data size conversion, such as:

`CheckExtension()`

Checks if the file is part of a list of extensions provided by the user. The list can be easily built using the `Signatures` `Enum`.

`IsUnderSize()`

Checks if the file is below a given size, in Bytes. You can use the `static` methods `FromKilobytes()` and `FromMegabytes()` to easily convert values from one size to another.

## WIP

### Planned Features

- Metadata

Retrieval of any Metadata information contained in the file, such as the ones in a Exif container.

### Improvements

- Remove the usage of `List` on dictionaries.

Since some file extensions have many different signatures, I decided to use a `List` to group them up, instead of making different extensions for them. Perhaps replace the `Dictionary` with a `Lookup` in the future.

- Add more file extensions!

Only common file extensions have been added. More will come in the future.

## Considerations

- The maximum supported file size is 16 Exabytes, limited by the `ulong` data type. Have fun!
- Some file extensions have been split given their differences in relation to Metadata (ex.: `JPEG` and `JExif` for JPEGs with and without an Exif container, respectively)
- This library is still in development, so expect some bugs.

