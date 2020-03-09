all: out.txt
	cat out.txt

out.txt: cmdline.exe input.txt Makefile
	mono $< 1 2 3 4 5 1> $@


cmdline.exe:cmdline.cs
	mcs $<

clean:
	$(RM) *.exe out*

