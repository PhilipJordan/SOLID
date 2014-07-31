# -*- encoding: utf-8 -*-

Gem::Specification.new do |s|
  s.name = "gherkin"
  s.version = "2.12.2"
  s.platform = "x86-mingw32"

  s.required_rubygems_version = Gem::Requirement.new(">= 0") if s.respond_to? :required_rubygems_version=
  s.authors = ["Mike Sassak", "Gregory Hnatiuk", "Aslak Helles\u{f8}y"]
  s.date = "2013-10-12"
  s.description = "A fast Gherkin lexer/parser based on the Ragel State Machine Compiler."
  s.email = "cukes@googlegroups.com"
  s.homepage = "http://github.com/cucumber/gherkin"
  s.licenses = ["MIT"]
  s.rdoc_options = ["--charset=UTF-8"]
  s.require_paths = ["lib"]
  s.rubygems_version = "1.8.28"
  s.summary = "gherkin-2.12.2"

  if s.respond_to? :specification_version then
    s.specification_version = 4

    if Gem::Version.new(Gem::VERSION) >= Gem::Version.new('1.2.0') then
      s.add_runtime_dependency(%q<multi_json>, ["~> 1.3"])
      s.add_development_dependency(%q<cucumber>, [">= 1.3.8"])
      s.add_development_dependency(%q<rake>, [">= 10.1.0"])
      s.add_development_dependency(%q<bundler>, [">= 1.3.5"])
      s.add_development_dependency(%q<rspec>, ["~> 2.14.1"])
      s.add_development_dependency(%q<rubyzip>, [">= 1.0.0"])
      s.add_development_dependency(%q<ruby-beautify>, ["= 0.92.2"])
      s.add_development_dependency(%q<therubyracer>, [">= 0.12.0"])
      s.add_development_dependency(%q<yard>, [">= 0.8.7.2"])
      s.add_development_dependency(%q<rdiscount>, [">= 2.1.6"])
      s.add_development_dependency(%q<builder>, [">= 3.2.2"])
    else
      s.add_dependency(%q<multi_json>, ["~> 1.3"])
      s.add_dependency(%q<cucumber>, [">= 1.3.8"])
      s.add_dependency(%q<rake>, [">= 10.1.0"])
      s.add_dependency(%q<bundler>, [">= 1.3.5"])
      s.add_dependency(%q<rspec>, ["~> 2.14.1"])
      s.add_dependency(%q<rubyzip>, [">= 1.0.0"])
      s.add_dependency(%q<ruby-beautify>, ["= 0.92.2"])
      s.add_dependency(%q<therubyracer>, [">= 0.12.0"])
      s.add_dependency(%q<yard>, [">= 0.8.7.2"])
      s.add_dependency(%q<rdiscount>, [">= 2.1.6"])
      s.add_dependency(%q<builder>, [">= 3.2.2"])
    end
  else
    s.add_dependency(%q<multi_json>, ["~> 1.3"])
    s.add_dependency(%q<cucumber>, [">= 1.3.8"])
    s.add_dependency(%q<rake>, [">= 10.1.0"])
    s.add_dependency(%q<bundler>, [">= 1.3.5"])
    s.add_dependency(%q<rspec>, ["~> 2.14.1"])
    s.add_dependency(%q<rubyzip>, [">= 1.0.0"])
    s.add_dependency(%q<ruby-beautify>, ["= 0.92.2"])
    s.add_dependency(%q<therubyracer>, [">= 0.12.0"])
    s.add_dependency(%q<yard>, [">= 0.8.7.2"])
    s.add_dependency(%q<rdiscount>, [">= 2.1.6"])
    s.add_dependency(%q<builder>, [">= 3.2.2"])
  end
end
