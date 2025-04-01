CXX = g++
CXXFLAGS = -Wall -std=c++14

TARGET = FileHandler
SRCDIR = src
BUILDDIR = build

SRCS = $(wildcard $(SRCDIR)/Application/*.cpp) $(wildcard $(SRCDIR)/EntryPoint/*.cpp) $(wildcard $(SRCDIR)/Presentation/*.cpp)
OBJS = $(patsubst $(SRCDIR)/%.cpp, $(BUILDDIR)/%.o, $(SRCS))

all: $(TARGET) run

$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS) -o $(TARGET) $^

$(BUILDDIR)/%.o: $(SRCDIR)/%.cpp
	@mkdir -p $(dir $@)
	$(CXX) $(CXXFLAGS) -c $< -o $@

run: $(TARGET)
	./$(TARGET)

clean:
	rm -f $(TARGET) $(OBJS)

.PHONY: all clean run