CXX = g++

CXXFLAGS = -Wall -std=c++11
 
TARGET = LeapYear
 
SRCDIR = src

SRCS = $(wildcard $(SRCDIR)/Entity/*.cpp) $(wildcard $(SRCDIR)/Application/*.cpp) $(wildcard $(SRCDIR)/EntryPoint/*.cpp) $(wildcard $(SRCDIR)/Presentation/*.cpp)
 
OBJS = $(SRCS:.cpp=.o)
 
all: $(TARGET) run
 
$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS) -o $(TARGET) $^
 
%.o: %.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@
 
run: $(TARGET)
	./$(TARGET)
 
clean:
	rm -f $(TARGET) $(OBJS)
 
.PHONY: all clean run
 