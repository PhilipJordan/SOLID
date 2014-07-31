require "yml_reader/version"

module YmlReader

  #
  # Set the directory to use when reading yml files
  #
  def yml_directory=(directory)
    @yml_directory = directory
  end

  #
  # Returns the directory to be used when reading yml files
  #
  def yml_directory
    return @yml_directory if @yml_directory
    return default_directory if self.respond_to? :default_directory
    nil
  end

  #
  # Loads the requested file.  It will look for the file in the
  # directory specified by a call to the yml_directory= method.
  #
  def load(filename)
    @yml = YAML.load(ERB.new(File.read("#{yml_directory}/#{filename}")).result)
  end
  
end
