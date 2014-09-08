# -*- encoding: utf-8 -*-
require File.expand_path('../lib/yml_reader/version', __FILE__)

Gem::Specification.new do |gem|
  gem.authors       = ["Jeffrey S. Morgan"]
  gem.email         = ["jeff.morgan@leandog.com"]
  gem.description   = %q{Sets a directory and reads yml files}
  gem.summary       = %q{Sets a directory and reads yml files}
  gem.homepage      = "http://github.com/cheezy/yml_reader"

  gem.executables   = `git ls-files -- bin/*`.split("\n").map{ |f| File.basename(f) }
  gem.files         = `git ls-files`.split("\n")
  gem.test_files    = `git ls-files -- {test,spec,features}/*`.split("\n")
  gem.name          = "yml_reader"
  gem.require_paths = ["lib"]
  gem.version       = YmlReader::VERSION
end
