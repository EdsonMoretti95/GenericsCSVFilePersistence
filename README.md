# GenericsCSVFilePersistence

This project contains the implementation of a generic list that can persist to CSV.
It uses reflection to get the attributes of the list objects and go through them to persist in the file.
It's just an initial implementation so it only supports objects which have attributes that are of types int, string, bool, char, double or datetime.
