#! /bin/sh

mono 漢字.exe $1 > $2.hs
ghc -o $2 $2.hs
